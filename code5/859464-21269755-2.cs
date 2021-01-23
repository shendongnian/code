    foreach (string arg in args)
    {
        var temp = arg;
        if (queryable == null)
        {
            queryable = context.IdsForms.Where(f => f.MatterNumber.StartsWith(temp)).Select(f => f.MatterNumber);
        }
        else
        {
            queryable = queryable.Union(context.IdsForms.Where(f => f.MatterNumber.StartsWith(temp)).Select(f => f.MatterNumber));
        }
    }
