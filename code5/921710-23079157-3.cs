    void Main()
    {
        var myInstance = new myClass();
        var equalsMethod = typeof(Int32?).GetMethod("Equals", new[] { typeof(Int32?) });
        int? nullableInt = 1;
        var nullableIntExpr = System.Linq.Expressions.Expression.Constant(nullableInt);
        var myInstanceExpr = System.Linq.Expressions.Expression.Constant(myInstance);
        var propertyExpr = System.Linq.Expressions.Expression.Property(myInstanceExpr, "MyProperty");
        var result = Expression.Call(propertyExpr,equalsMethod,nullableIntExpr); // This line throws the exception.
        Console.WriteLine(result);
    }
    
    class myClass{public int? MyProperty{get;set;}}
