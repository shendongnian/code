        [TestCase(2019, 10,21,true)]
        [TestCase(2019, 11, 31, false)] //november doesnt have 31, only 30
        [TestCase(2016, 2, 29, true)] // is leap
        [TestCase(2014, 2, 29, false)] // is nop leap
        public static void ValidateYearMonthDay(int year, int month, int day, bool expectedresult)
        {
            var result = Date.IsValidYearMonthDay(year, month, day);
            Assert.AreEqual(expectedresult, result);
        }
