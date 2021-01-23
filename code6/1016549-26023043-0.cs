    using(YourEFContext ctx = new YourEFContext())
    {
        NewsTbl news = new NewsTbl();
        // set some properties here on "news".....
        ctx.NewsTbl.Add(news);
        ctx.SaveChanges();
    }
