    var db = new ApplicationDbContext();
    db.Comments.Add(new Comment()
        {
            AddDate = DateTime.Now,
            Body = "asd",
            IsApproved = true,
            LikeCount = 12,
            Member = new Member(),
            Post = new Post()
        });
    db.SaveChanges();
