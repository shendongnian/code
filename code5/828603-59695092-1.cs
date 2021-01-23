    public class DateHelperUnitTests
    {
        [Theory]
        [InlineData(2020, 1, 7, 2020, 1, 7)]
        [InlineData(2020, 1, 8,  2020, 1, 7)]
        [InlineData(2020, 1, 9,  2020, 1, 7)]
        [InlineData(2020, 1, 10, 2020, 1, 7)]
        [InlineData(2020, 1, 11, 2020, 1, 7)]
        [InlineData(2020, 1, 12, 2020, 1, 7)]
        [InlineData(2020, 1, 13, 2020, 1, 7)]
        [InlineData(2020, 1, 14, 2020, 1, 14)]
        [InlineData(2020, 1, 15, 2020, 1, 14)]
        public void GetDateForLastDayOfWeek_MultipleValues_Pass(
            int InputYear, int InputMonth, int InputDay,
            int ExpectedYear, int ExpectedMonth, int ExpectedDay)
        {
            DateTime DateToTest = new DateTime(InputYear, InputMonth, InputDay);
            DateTime NewDate = DateHelper.GetDateForLastDayOfWeek(DayOfWeek.Tuesday, DateToTest);
            DateTime DateExpected = new DateTime(ExpectedYear,ExpectedMonth,ExpectedDay);
            Assert.True(0 == DateTime.Compare(DateExpected.Date, NewDate.Date));
        }
        [Theory]
        [InlineData(2020, 1, 7, 2020, 1, 14)]
        [InlineData(2020, 1, 8, 2020, 1, 14)]
        [InlineData(2020, 1, 9, 2020, 1, 14)]
        [InlineData(2020, 1, 10, 2020, 1, 14)]
        [InlineData(2020, 1, 11, 2020, 1, 14)]
        [InlineData(2020, 1, 12, 2020, 1, 14)]
        [InlineData(2020, 1, 13, 2020, 1, 14)]
        [InlineData(2020, 1, 14, 2020, 1, 21)]
        [InlineData(2020, 1, 15, 2020, 1, 21)]
        public void GetDateForNextDayOfWeek_MultipleValues_Pass(
            int InputYear, int InputMonth, int InputDay,
            int ExpectedYear, int ExpectedMonth, int ExpectedDay)
        {
            DateTime DateToTest = new DateTime(InputYear, InputMonth, InputDay);
            DateTime NewDate = DateHelper.GetDateForNextDayOfWeek(DayOfWeek.Tuesday, DateToTest);
            DateTime DateExpected = new DateTime(ExpectedYear, ExpectedMonth, ExpectedDay);
            Assert.True(0 == DateTime.Compare(DateExpected.Date, NewDate.Date));
        }
    }
