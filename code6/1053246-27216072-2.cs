     var query = from p in db.Post.Where(p => p.PostID == PostID)
                 from comments in db.Comments.Where(p => p.PostID == PostID)
                     join u in db.User
                     on p.UserID equals u.UserID
                     where p.PostID == PostID
                     select new ListPostsVM()
                     {
                         PostTitle = p.PostTitle,
                         PostContent = p.PostContent,
                         PostDate = p.PostDate,
                         Username = u.Username
                         Comments = comments
                     };
        return View(query.Single());
