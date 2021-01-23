    using(dbContext db = new dbContext())
    {
        for(int i = 0; i < list.Count - 1; i += 2)
        {
            var NewsItem = new News 
            {
                NewsTitle = list[i];
                NewsDescription = list[i+1];
            };
        
            db.News.Add(NewsItem);
        }
    }
    db.SaveChanges();
