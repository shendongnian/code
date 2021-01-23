    var firstName = Expression.Property(filterParam, "FirstName");
    var lastName = Expression.Property(filterParam, "LastName");
    var concat = Expression.Call(typeof(string).GetMethod("Concat", BindingFlags.Public |
                                                          BindingFlags.Static),
                                 firstName, lastName);
    BinaryExpression predicate = Expression.Equal(concat, right);
    //....
 
