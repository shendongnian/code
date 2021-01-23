    public List<ContextInstance> GetContextInstances(
           string[] ParamNames, string[] ParamValues, bool AsNoTracking = false)
    {
        var params = ParamNames
            .Zip(ParamValues, (a, b) => new KeyValuePair<string,string>(a, b));
        
        var ctx = db.ContextInstances
           .Where(x => params
              .Any(y => x.ContextParamValues
                 .Any(z => z.ContextParam.Name == y.Key && z.Value == y.Value)));
        
        return AsNoTracking ? ctx.AsNoTracking() : ctx;
    }
