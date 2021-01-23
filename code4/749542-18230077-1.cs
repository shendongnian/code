    string memberName = "Text1", value = "SomeString";
    var p = Expression.Parameter(typeof(SomeClass), "obj");
    var predicate = Expression.Lambda<Func<SomeClass, bool>>(
        Expression.Equal(
            Expression.PropertyOrField(p, memberName),
            Expression.Constant(value,typeof(string))
        ), p);
    var result = myList.AsQueryable().Where(predicate);
