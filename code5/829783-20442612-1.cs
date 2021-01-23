    [TestFixture]
    public class ConsecutiveDaysTests
    {
        [Test]
        public void ConsecutiveDayTest()
        {
            var dayList = new List<DateTime>
            {
                new DateTime(2013,12,07),
                new DateTime(2013,12,07),
                new DateTime(2013,12,06),
                new DateTime(2013,12,05),
                new DateTime(2013,12,04),
                new DateTime(2013,12,04),
                new DateTime(2013,11,11),
                new DateTime(2013,11,10),
                new DateTime(2013,11,04)
            };
            var result = dayList.GetConsecutiveDays(3).ToList();
            result.Should().HaveCount(2);
            result.First().ShouldBeEquivalentTo(new[]{new DateTime(2013,12,06),
                                                      new DateTime(2013,12,05),
                                                      new DateTime(2013,12,04)});
        }
    }
