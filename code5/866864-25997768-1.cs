    public void SavePost(Post post)
    {
        using (var db = new YourDatabase())
        {
            db.Posts.Add(post);
            db.SaveChanges();
        }
    }
