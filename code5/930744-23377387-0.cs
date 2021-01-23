    [WebGet]
    [Queryable]
    public IQueryable<UObject> GetObjects()
    {
    return list.Where(e=>e.Item>=2).AsQeryable<UObject>();
    }
