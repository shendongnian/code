    Type[] knownTypes = new Type[] 
    { 
        typeof(ArticlePage), 
        typeof(ArticleListPage),
        // ... etc.
    };
    
    var pageType = this.Page.GetType();
    if (knownTypes.Any(x => x.IsAssignableFrom(pageType)))
    {
        //Do something fantastic
    }
