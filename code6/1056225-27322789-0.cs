    public IEnumerable<Post> PostsForFlow(int userId)
    {
        var userIdsToFollow = db.Follow.Where(a =>
            a.loggedInUser.Id == userId).Select(b => b.userToFollow.Id);
        return db.Users
            .Where(u => userIdsToFollow.Contains(u.Id))
            .SelectMany(u => u.Posts);
    }
