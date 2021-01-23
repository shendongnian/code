    //you can make this private if you want
    public static IEnumerable<IList<Foo>> GetPages(int pageSize)
    {
        IList<Foo> nextGroup = ExecuteQuery();
        while (nextGroup.Count == pageSize)
        {
            yield return nextGroup;
            nextGroup = ExecuteQuery();
        }
        if (nextGroup.Any())
            yield return nextGroup;
    }
