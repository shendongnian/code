    Dictionary<DateTime, List<UserFeed>> feedGrouped = new Dictionary<DateTime,List<UserFeed>>();
    bool newGroup = false;
    int itemCount = 0;
    DateTime lastDate = new DateTime();
    foreach(var item in userFeed.OrderByDescending(I => I.Date).Take(15))
    {
        if (feedGrouped.Where(i => i.Key <= item.Date.AddSeconds(7)).Any() && newGroup == false)
        {
            if (newGroup == false)
            {
                feedGrouped.Where(i => i.Key <= item.Date.AddSeconds(7)).FirstOrDefault().Value.Add(item);
                if (userFeed.ElementAtOrDefault(itemCount + 1).Date.AddSeconds(7) >= lastDate)
                {
                    newGroup = true;
                }
            }
        }
        else
        {
            List<UserFeed> newList = new List<UserFeed>();
            newList.Add(item);
            feedGrouped.Add(item.Date, newList);
            newGroup = false;
            lastDate = item.Date;
        }
        itemCount += 1;
    }
