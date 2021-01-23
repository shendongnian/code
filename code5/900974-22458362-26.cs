    var param = Expression.Parameter(typeof(int), "x");
    var seed = (Expression<Func<int, bool>>)
        Expression.Lambda(Expression.Constant(true), 
        param);
    var visitor = new Visitor(param);
    
    var allTogether = tests.Aggregate(
        seed,
        (combined, expr) => (Expression<Func<int, bool>>)
            Expression.Lambda(
            Expression.And(combined.Body, expr.Body), 
            param
        ),
        lambda => (Expression<Func<int, bool>>)
            // replacing all ParameterExpressions with same instance happens here
            Expression.Lambda(visitor.Visit(lambda.Body), param)
        );
        
    Console.WriteLine(allTogether.Compile().Invoke(30)); // "True" -- works! 
