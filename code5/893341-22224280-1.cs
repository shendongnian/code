    private static string GetSomething(IQueryable<EnumTest> things)
    {
        var expression = Program.ConvertToString;
    
        var ret = things
            .AsExpandable()
            .Select(c => expression.Invoke(c.SomeEnum))
            .First();
        return ret;
    }
