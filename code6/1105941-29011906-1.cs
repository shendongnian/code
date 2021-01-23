    public ActionResults Index() {
        var posts = _db.Posts.Select(x => new Post {
            Title = x.Title,
            IsLikedByCurrentUser = x.PostLike.Select(y => y.UserId).Contains(User.Id)
        });
        return View();
    }
