    List<ListItem> entitiesList = new List<ListItem>();
    //some code to fill the list
    var duplicates = entitiesList.OrderByDescending(e => e.createdon)
                        .GroupBy(e => e.accountNumber)
                        .Where(e => e.Count() > 1)
                        .Select(g => new
                        {
                            MostRecent = g.FirstOrDefault(),
                            Others = g.Skip(1).ToList()
                        });
    
    foreach (var item in duplicates)
    {
        ListItem mostRecent = item.MostRecent;
        List<ListItem> others = item.Others;
        //do stuff with others
    }
