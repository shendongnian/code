    var viewsById = db.ArticleViews
        .Where(av => av.ViewCreated >= startDateTime and av.ViewCreated < endDateTime)
        .GroupBy(av => av.ArticleId)
        .Select(g => new { ArticleId = g.Key, Count = g.Count() })
        .Max(g => g.Count);
                        
    var message = String.Format("Article id: {0}, views: {1}", 
                             viewsById.ArticleId, viewsById.Count);
