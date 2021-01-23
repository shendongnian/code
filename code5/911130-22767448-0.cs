    IQueryable<Article> articles = db.Articles;
    if (User.IsInRole("Admin"))
    {
        // No change...
    }
    else if (User.IsInRole("Educator"))
    {
        articles = articles.Where(s => s.createdBy == WebSecurity.CurrentUserName);
    }
    else
    {
        // Throw an exception? What do you want to happen if they're neither an
        // educator nor an administrator?
    }
