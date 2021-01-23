    private static IEnumerable<Expression> GetConditions(Expression instance, Expression searchTerm)
    {
        // note: if you have properties like FullName that don't map directly
        // to database columns, you'll need to filter those out here
        var stringProperties = @object.Type.GetProperties()
            .Where(p => p.PropertyType == typeof(string));
    
        // GetMethod from 
        // http://www.codeducky.org/10-utilities-c-developers-should-know-part-two/
        var containsMethod = Helpers.GetMethod((string s) => s.Contains(default(string)));
    
        // for each property, generate an expression 
        // instance.Prop.Contains(searchTerm)
        return stringProperties.Select(p => 
            Expression.Call(
                Expression.MakeMemberAccess(instance, p),
                containsMethod,
                searchTerm
            )
        );
    }
    
    // use the above method like so:
    var bookParameter = Expression.Parameter(typeof(AddressBook));
    var personInfo = Expression.MakeMemberAccess(
        bookParameter, 
        typeof(AddressBook).GetProperty("PersonInfo")
    );
    // ... create more for other complex types
    var searchTermExpression = Expression.Constant(searchTerm);
    
    var allConditions = GetConditions(bookParameter, searchTermExpression)
        .Concat(GetConditions(personInfo, searchTermExpression))
        // ... add conditions for other complex types
    
    // combine the conditions into a single expression with OR:
    // ab.RecordName.Contains(...) || ab.PersonInfo.Name.Contains(...)...
    var combinedCondition = allConditions.Aggregate(Expression.OrElse);
    
    // create a lambda which you can pass to Where()
    // ab => ab.RecordName.Contains(...) || ab.PersonInfo.Name.Contains(...)...
    var lambda = Expression.Lambda<Func<AddressBook, bool>>(
        combinedCondition,
        bookParameter
    );
    
    // filter the query
    var filtered = ctxt.AddressBooks.Where(lambda);
