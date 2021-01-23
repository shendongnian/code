     public static void Test2<TTable>(IQueryable<TTable> table, Expression<Func<TTable, int>> idFunc, Expression<Func<TTable, string>>> nameExpr)
     {
       var intVal = 1;
 
       var variableParam = Expression.Parameter(typeof(int));
       var equalExpr = Expression.Equal(idFunc.Body, variableParam);
       var lambaWrap = Expression.Lambda<Func<TTable, bool>>(equalExpr, (ParameterExpression)((MemberExpression)idFunc.Body).Expression);
       var lambdaDoubleWrap = Expression.Lambda<Func<int, Expression<Func<TTable, bool>>>>(lambaWrap, variableParam).Compile();
 
       var dbName = table.Where(lambdaDoubleWrap(intVal)).Select(nameExpr).SingleOrDefault();
 
       //assert
     }
