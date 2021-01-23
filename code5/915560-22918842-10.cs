    public void LoadFeedAndStore()
    {
       var feed = LoadFeed();
       var db = new BlogContext();
        
        foreach(var item in feed.Items)
        {
           db.Posts.Add(
            new Post { 
                Body = item.Summary == null ? "<empty>":  item.Summary.Text 
                });
        }
        db.SaveChanges();
    }
