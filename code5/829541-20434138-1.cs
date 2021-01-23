    Dictionary<DateTime, List<UserFeed>> feedGrouped = new Dictionary<DateTime,List<UserFeed>>();
    foreach(var item in userFeed.OrderByDescending(I => I.Date))
    {
        if(feedGrouped.Count >= 15)
            break;
        if (feedGrouped.Where(i => i.Key <= item.Date.AddSeconds(7)).Any())
        {
            feedGrouped.Where(i => i.Key <= item.Date.AddSeconds(7)).FirstOrDefault().Value.Add(item);
        }
        else
        {
            feedGrouped.Add(item.Date, new List<UserFeed> { item });
        }
    }
