    var statisticList = (from item in Connection.DBConnection.TBStatistics
                                     where item.Date >= startDate && item.Date <= endDate
                                     group item by item.Customer into grp
                                     where grp.Any()
                                     select new StatisticsGroup
                                     {
                                         Customer = grp.Key,
                                         Count = grp.Count(),
                                         TBStatisticRecords = grp.Select(p=> p)
                                     }).ToList();
