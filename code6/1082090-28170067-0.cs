    var posts = Post.SeedPosts();
    var tagGroups = posts
                     .SelectMany(p => p.Tags, (post, tag) => new{Tag = tag, post.Title})
                     .GroupBy(pair => pair.Tag);
    foreach (var tagGroup in tagGroups)
    {
        Console.WriteLine(tagGroup.Key);
        foreach (var pair in tagGroup)
        {
            Console.WriteLine("  " + pair.Title);
        }
    }
    Console.ReadKey();
