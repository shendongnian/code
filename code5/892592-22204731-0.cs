    using (var dbContext = new db_ReadyEngine_MSSQL())
    {
        var entity = dbContext.Set<tbl_ObisSchema>().Find(thePrimaryKeyToFind);
        if (entity == null) throw new InvalidOperationException("Record not found");
        
        var entry = dbContext.Entry(entity);
        var currentPropertyValues = entry.CurrentValues;
        
        List<Tuple<string, object>> list = currentPropertyValues.PropertyNames
            .Select(name => Tuple.Create(name, currentPropertyValues[name]))
            .ToList();
        
        // Do something with the list...
    }
