    private static IList<IDictionary<string, Guid>> MyIntermediateFuncForAReason()
    {
        var originalList = GetList();
        //whatever processing.
        return originalList.Select((IDictionary<string, Guid> i) => i).ToList();
    }
