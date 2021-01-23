    bool checkTitle = ...
    bool checkDescription = ...
    string likeString = ...
    var res = context.Category
        .Where(item =>
            (checkTitle && item.Title.Contains(likeString))
            ||
            (checkDescription && item.Description.Contains(likeString))
        );
        
