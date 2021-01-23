    public IEnumerable<TEntity> GetPublished<TEntity>()
        where TEntity : IPublishable
    {
        return GetQueryable<TEntity>(
            m => m.Status == PublishStatus.Published && m.PublishDate <= DateTime.Now,
            m => m.OrderByDescending(o => o.PublishDate)
        ).ToList();
    }
