    public IEnumerable<Blog> Top6BlogCategories()
    {
        // Get Blog posts
        IEnumerable<Blog> posts = db.Blogs.ToList();
        // Get Blog Categories
        IEnumerable<string> categories = Categories();
        // Create a variable to hold the Category and its Hits
        List<KeyValuePair<string, int>> categoryHits = new List<KeyValuePair<string,int>>();
        // Populate the List's first column (Category)
        foreach(var category in categories)
        {
            categoryHits.Add(new KeyValuePair<string, int>(category, posts.Count(post => post.Category == category)));
        }
        return posts;
    }
