    var statisticList = (from item in Connection.DBConnection.TBStatistics       
              where item.Date >= startDate && item.Date <= endDate
                         group item by item.Customer into grp
                         where grp.Any()
                         select new
                         {
                             Customer = grp.Key,
                             //Count = grp.Count(), Note I think we don't need it we can use GroupItems.Count instead
                             GroupItems = grp.ToList()
                         }).ToList();
    foreach (var Cus in statisticList)
    {
        //Do whatever with Cus.GroupItems
    }
