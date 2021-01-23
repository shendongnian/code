     var query = from p in db.Post
                     join u in db.User
                     on p.UserID equals u.UserID
                     where p.PostID == PostID
                     select new ListPostsVM()
                     {
                         PostTitle = p.PostTitle,
                         PostContent = p.PostContent,
                         PostDate = p.PostDate,
                         Username = u.Username
    
                     };
        return View(query.Single());
