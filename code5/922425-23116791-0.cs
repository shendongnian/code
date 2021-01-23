    [HttpPost]
    public ActionResult Create(Post post, int[] tags) 
    {
         ...
         var freshPost = db.Posts.Find(post.ID);
         freshPost.Tags.Clear();
         foreach (var tag in tags)
         {
             Tag t = db.ThemeFeatures.Find(tag);
             freshPost.Tags.Add(t);
         }
    
         context.SaveChanges();
    }
