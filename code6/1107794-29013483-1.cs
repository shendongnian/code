    using (testEntities ctx = new testEntities())
    {
        ObjectResult<int?> result = ctx.GetListOfInt();
        foreach (int intValue in result.AsEnumerable())
        {
            Console.WriteLine("INT value returned: {0}", intValue);
        }
    }
