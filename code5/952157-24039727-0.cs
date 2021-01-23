    IEnumerable<IDictionary<string, object>> GetValues<T>(DataContext context,
                                                             IQueryable<T> query)
        where T : class
    {
        var propertyInfos = typeof(T).GetProperties().ToDictionary (pi => pi.Name);
        foreach(var entity in context.GetTable<T>())
        {
            yield return (context.Mapping.GetTable(typeof(T)).RowType.DataMembers
               .Where(dm => !dm.IsAssociation).Select (dm => dm.Name)
            .Select(name => new { name, 
                                  value = propertyInfos[name].GetValue(entity, null)
                                })
            .ToDictionary (x => x.name, y => y.value));
        }
    }
