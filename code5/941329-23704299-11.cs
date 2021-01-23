    public List<ContextInstance> GetContextInstances(
           string[] ParamNames, string[] ParamValues, bool AsNoTracking = false)
    {
        var p = ParamNames.Zip(ParamValues, (a,b) => a+b);
        var ctx = db.ContextInstances
           .Where(x => p.All(y => x.ContextParamValues
              .Select(z => z.ContextParam.Name + z.Value).Contains(y)));
        return (AsNoTracking ? ctx.AsNoTracking() : ctx).ToList();
    }
