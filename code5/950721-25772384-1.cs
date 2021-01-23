    [TestMethod]
            public void TimeRangeFilter_timeFrom_is_smaller_than_timeTo()
            {
                // arrange
                List<DateTime> dates = new List<DateTime>() 
                {
                    DateTime.Today.AddHours(2), // 2 AM
                    DateTime.Today.AddHours(9), // 9 AM
                    DateTime.Today.AddHours(12), // 12 PM
                    DateTime.Today.AddHours(15), // 3 PM
                    DateTime.Today.AddHours(18), // 6 PM
                    DateTime.Today.AddHours(23).AddMinutes(50), // 11:50 PM
                    DateTime.Today, // 0 AM
                };
                // interval: 10 AM to 4 PM
                DateTime timeFrom = DateTime.Today.AddHours(10), timeTo = DateTime.Today.AddHours(16);
                
                // act
                var datesInPeriod = dates.Where(p => p.IsInTimeRange(timeFrom, timeTo));
                
                // assert
                Assert.IsFalse(datesInPeriod.Any(p => p.Hour == 2));
                Assert.IsFalse(datesInPeriod.Any(p => p.Hour == 9));
                Assert.IsTrue(datesInPeriod.Any(p => p.Hour == 12));
                Assert.IsTrue(datesInPeriod.Any(p => p.Hour == 15));
                Assert.IsFalse(datesInPeriod.Any(p => p.Hour == 18));
                Assert.IsFalse(datesInPeriod.Any(p => p.Hour == 23));
                
            }
    
            [TestMethod]
            public void TimeRangeFilter_timeFrom_is_greater_than_timeTo()
            {
                // arrange
                List<DateTime> dates = new List<DateTime>() 
                {
                    DateTime.Today.AddHours(2), // 2 AM
                    DateTime.Today.AddHours(9), // 9 AM
                    DateTime.Today.AddHours(12), // 12 PM
                    DateTime.Today.AddHours(15), // 3 PM
                    DateTime.Today.AddHours(18), // 6 PM
                    DateTime.Today.AddHours(23).AddMinutes(50), // 11:50 PM
                    DateTime.Today, // 0 AM
                };
                // interval: 10 PM to 4 AM
                DateTime timeFrom = DateTime.Today.AddHours(22), timeTo = DateTime.Today.AddHours(4);
    
                // act
                var datesInPeriod = dates.Where(p => p.IsInTimeRange(timeFrom, timeTo));
    
                // assert
                Assert.IsTrue(datesInPeriod.Any(p => p.Hour == 2));
                Assert.IsFalse(datesInPeriod.Any(p => p.Hour == 9));
                Assert.IsFalse(datesInPeriod.Any(p => p.Hour == 12));
                Assert.IsFalse(datesInPeriod.Any(p => p.Hour == 15));
                Assert.IsFalse(datesInPeriod.Any(p => p.Hour == 18));
                Assert.IsTrue(datesInPeriod.Any(p => p.Hour == 23));
    
            }
