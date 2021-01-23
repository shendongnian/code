    private static Action<IDataReader, T> GetMapFunc()
    {
        var exps = new List<Expression>();
    
        var paramExp = Expression.Parameter(typeof(IDataRecord), "o7thDR");
        var targetExp = Expression.Parameter(typeof(T), "o7thTarget");
    
        var getPropInfo = typeof(IDataRecord).GetProperty("Item", new[] { typeof(string) });
    
    
        //basically get column names by looping thru reader
        var loopIncrementVariableExp = Expression.Parameter(typeof(int), "i");
        var columnNamesExp = Expression.Parameter(typeof(List<string>), "columnNames");
    
        var columnCountExp = Expression.Property(paramExp, "FieldCount");
        var getColumnNameExp = Expression.Call(paramExp, "GetName", new Type[] { }, Expression.PostIncrementAssign(loopIncrementVariableExp));
        var addToListExp = Expression.Call(columnNamesExp, "Add", new Type[] { }, getColumnNameExp);
        var labelExp = Expression.Label(columnNamesExp.Type);
    
        var loop = Expression.Block(
            new[] { loopIncrementVariableExp, columnNamesExp },
            Expression.Assign(columnNamesExp, Expression.New(columnNamesExp.Type)),
            Expression.Loop(
                Expression.IfThenElse(
                    Expression.LessThan(loopIncrementVariableExp, columnCountExp),
                    addToListExp,
                    Expression.Break(labelExp, columnNamesExp)),
                labelExp));
    
    }
    //pseduo-code: now loop thru column name and find property
    var columnNames = Expression.Lambda<Func<IDataRecord, List<string>>>(loop, paramExp);
    foreach (var columnName in columnNames)
    {
        var property = typeof(T).GetProperty(columnName);
        if (property == null)
            continue;
        var getPropExp = Expression.MakeIndex(paramExp, getPropInfo, new[] { Expression.Constant(property.Name) });
        var castExp = Expression.Convert(getPropExp, property.PropertyType);
        var bindExp = Expression.Assign(Expression.Property(targetExp, property), castExp);
        exps.Add(bindExp);
    }
    // return our compiled mapping, this will ensure it is cached to use through our record looping
    return Expression.Lambda<Action<IDataReader, T>>(Expression.Block(exps), paramExp, targetExp).Compile();
