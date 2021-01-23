     public static void Test<TTable>(IQueryable<TTable> table, Expression<Func<TTable, int>> idFunc, Expression<Func<TTable, string>>> nameExpr)
     {
       var intVal = 1;
       var constant = Expression.Constant(intVal, typeof(int));
       var equalExpr = Expression.Equal(idFunc.Body, constant);
       var lambaWrap = Expression.Lambda<Func<TTable, bool>>(equalExpr, (ParameterExpression)((MemberExpression)idFunc.Body).Expression);
 
       var dbName = table.Where(lambaWrap).Select(nameExpr).SingleOrDefault();
 
       //assert
     }
