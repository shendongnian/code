    public IEnumerable<CommonPersonFeatureValue> QueryThings<TThing>(IQueryable<TThing> things)
        where TThing : IThing
    {
        var query = from c in things
                    select new CommonPersonFeatureValue
                    {
                        PersonId = c.PersonId ?? 0,
                        Created = c.Created ?? DateTime.MinValue,
                        CurStatus = String.IsNullOrEmpty(c.CurStatus) ? c.CurStatus : String.Empty,
                        NewStatus = String.IsNullOrEmpty(c.NewStatus) ? c.NewStatus : String.Empty,
                        Modified = c.Modified ?? DateTime.MinValue
                    };
        return query;
    }
