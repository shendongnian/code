    public IQueryable<T> AddTagsFilterToUniqueObject(IQueryable<T> query, 
                                       List<int> tags) where T : IUniqueObject 
    { 
        var ts = ItemTagSet;
        query = query.Where(f => ts.Any(e => e.TaggedItemUid == (f.Uid && tags.Contains(e.TagId));
 
        return query;
    }
