    var mostViewedArticle = db.ArticleViews
        .Where(av => av.ViewCreated >= startDateTime && av.ViewCreated < endDateTime)
        .GroupBy(av => av.ArticleId)
        .OrderByDescending(g=> g.Count())
        .Select(g => g.First().Article)
        .Take(1)
