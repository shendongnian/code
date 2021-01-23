    Type t = typeof(DB.TestTable);
    var s = Expression.Parameter(t, "s");
    var l1 = Expression.Lambda(
        typeof(Func<,>).MakeGenericType(t, typeof(bool)),
        Expression.LessThan(
            Expression.PropertyOrField(s, "Id"), 
            Expression.Constant(113)
        ),
        s
    );
    var query = repo.GetType()
        .GetMethod("fnExecute")
        .MakeGenericMethod(t).Invoke(repo, new object[] {l1});
