    foreach (string categoryName in selectedCategories)
    {
        Category category = LoadCategoryForName(categoryName);
        PostMapping postMap = new PostMapping();
        postMap.Category = category;
        postMap.Post = post;
        // Add the maps to cat and post
        post.PostMaps.Add(postMap);
        category.PostMaps.Add(postMap);
    }
    
    // update the db.
