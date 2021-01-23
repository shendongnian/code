    public void Test<TTable>(IQueryable<TTable> table,
        Expression<Func<TTable, int>> idSelector,
        Expression<Func<TTable, string>> nameSelector)
    {
        int idValue = 1;
        var filter = idSelector.Compose(id => id == idValue);
        var dbName = table.Where(filter)
            .Select(nameSelector)
            .SingleOrDefault();
        //make assertions
    }
