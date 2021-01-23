    [TestMethod]
    public void TestPeriods()
    {
        var periods = new[]
                        {
                            new Period(new DateTime(2014, 01, 01), new DateTime(2014, 04, 30)),
                            new Period(new DateTime(2014, 05, 01), new DateTime(2014, 07, 31)),
                            new Period(new DateTime(2014, 08, 01), new DateTime(2014, 09, 30)),
                        };
        var days = from period in periods
                    let numberOfDays = (period.LastDay - period.FirstDay).Days + 1
                    from day in Enumerable.Range(0, numberOfDays)
                    select period.FirstDay.AddDays(day);
        var distinctDays = days.Distinct().ToArray();
        distinctDays.Should().Contain(new DateTime(2014, 01, 01));
        distinctDays.Should().Contain(new DateTime(2014, 02, 01));
        distinctDays.Should().Contain(new DateTime(2014, 04, 30));
        distinctDays.Should().NotContain(new DateTime(2014, 10, 01));
    }
    public class Period
    {
            public Period(DateTime firstDay, DateTime lastDay)
            {
                this.FirstDay = firstDay;
                this.LastDay = lastDay;
            }
            public DateTime FirstDay {get;set;}
            public DateTime LastDay {get;set;}
    }
