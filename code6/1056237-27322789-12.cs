    public static void Main()
    {
        PopulateDb();
        var postsForFlow = PostsForFlow(0);
        // Now postsForFlow has 36 entries - 4 for each
        // of the 9 users that user '0' is following
        Console.WriteLine(postsForFlow.Count());
        // Output: 36 (9 users * 4 posts each)
        // Now, to test it further, stop following all users who have even Ids
        // This will leave us with 5 users: 1, 3, 5, 7, 9
        foreach (var follow in db.Follow
            .Where(f => f.userToFollow.Id % 2 == 0)
            .ToList())
        {
            db.Follow.Remove(follow);
        }
        postsForFlow = PostsForFlow(0);
        Console.WriteLine(postsForFlow.Count());
        // Output: 20 (5 users * 4 posts each)
    }
