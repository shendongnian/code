    Media mediaAlias = null;
    MediaCategory categoryAlias = null;
    return session.QueryOver<Product>()
        .JoinAlias(x => x.Medias, () => mediaAlias)
        .JoinAlias(() => mediaAlias.Categories, () => categoryAlias)
        .Fetch(x => x.Sellers).Eager
        .Where(() => categoryAlias.Id == mediaCategoryId)
        .List();
