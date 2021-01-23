    var paramExp = Expression.Parameter(typeof(IDataRecord), "o7thDR");
    var loopIncrementVariableExp = Expression.Parameter(typeof(int), "i");
    var columnNamesExp = Expression.Parameter(typeof(List<string>), "columnNames");
    var columnCountExp = Expression.Property(paramExp, "FieldCount");
    var getColumnNameExp = Expression.Call(paramExp, "GetName", Type.EmptyTypes, 
        Expression.PostIncrementAssign(loopIncrementVariableExp));
    var addToListExp = Expression.Call(columnNamesExp, "Add", Type.EmptyTypes, 
        getColumnNameExp);
    var labelExp = Expression.Label(columnNamesExp.Type);
    var getColumnNamesExp = Expression.Block(
        new[] { loopIncrementVariableExp, columnNamesExp },
        Expression.Assign(columnNamesExp, Expression.New(columnNamesExp.Type)),
        Expression.Loop(
            Expression.IfThenElse(
                Expression.LessThan(loopIncrementVariableExp, columnCountExp),
                addToListExp,
                Expression.Break(labelExp, columnNamesExp)),
            labelExp));
