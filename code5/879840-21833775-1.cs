    var model = posts.Select(m => new PostViewModel
    {
        Title = m.Title,
        Content = m.Content,
        ...
    }
