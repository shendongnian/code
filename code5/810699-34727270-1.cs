        [TestCase(2016, 1, 2016, 1, 4)]
        [TestCase(2016, 2, 2016, 1, 11)]
        [TestCase(2016, 52, 2016, 12, 26)]
        [TestCase(2014, 1, 2013, 12, 30)]
        public void FirstDateOfWeek_ShouldReturnCorrectDay(int year, int weekNumber, int correctYear, int correctMonth, int correctDay)
        {
            var helper = new DateHelper();
            var result = helper.FirstDateOfWeek(year, weekNumber);
            Assert.That(result.Year, Is.EqualTo(correctYear));
            Assert.That(result.Month, Is.EqualTo(correctMonth));
            Assert.That(result.Day, Is.EqualTo(correctDay));
        }
