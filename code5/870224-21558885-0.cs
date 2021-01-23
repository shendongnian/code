    public IEnumerable<Group> GetStaticMeasures(int businessUnitID)
    {
        var groups = ctx.Groups
                       .Include("Datapoints")
                       .Where(w => w.BusinessUnitID.Equals(businessUnitID))
                       .OrderBy(o => o.SortOrder);
        
        foreach(var g in groups)
        {
           g.Datapoints = g.Datapoints.OrderBy(d => d.SortOrder).ToList();
           yield return g;
        }
    }
