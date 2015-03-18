using System;
using Expedia;
using NUnit.Framework;

namespace ExpediaTest
{
	[TestFixture()]
	public class FlightTest
	{
        private readonly DateTime startDate = new DateTime(2015,3, 17);
        private readonly DateTime endDate = new DateTime(2015, 3, 27);
        private readonly int miles = 50;

        private readonly DateTime fifteenStart = new DateTime(2015, 3, 10);
        private readonly DateTime fifteenEnd = new DateTime(2015, 3, 25);

        [Test()]
        public void TestTHatHotelInitializes()
        {
            var target = new Flight(startDate,endDate,miles);
            Assert.IsNotNull(target);
        }

        [Test()]

        public void TestThatFlightHasCorrectBasePriceForTenDays()
        {
            var target = new Flight(startDate, endDate, miles);
            Assert.AreEqual(400, target.getBasePrice());
        }

        [Test()]

        public void TestThatFlightHasCorrectBasePriceForfifteenDays()
        {

            var target = new Flight(fifteenStart, fifteenEnd, miles);
            Assert.AreEqual(500, target.getBasePrice());
        }

        [Test()]

        public void TestThatFlightHasCorrectBasePriceForTwentyDays()
        {

            var target = new Flight(new DateTime(2015,3,5), new DateTime(2015,3,25), miles);
            Assert.AreEqual(600, target.getBasePrice());
        }

        [Test()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestThatFlightThrowsOnBadDates()
        {
            new Flight(new DateTime(2015, 3, 18), new DateTime(2014, 3, 19), miles);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestThatFlightThrowsOnBadMiles()
        {
            new Flight(startDate, endDate, -15);
        }

	}
}
