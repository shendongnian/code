    public IEnumerable<Article> GetPublishedArticles()
    {
        return GetQueryable<Article>(
            m => m.Status == PublishStatus.Published && m.PublishDate <= DateTime.Now,
            m => m.OrderByDescending(o => o.PublishDate)
        ).ToList();
    }
