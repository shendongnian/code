    using (var context = new Entities())
    {
    	var originalExpr = Person.GetFilterExpression("ivan");
    	Console.WriteLine("Original: " + originalExpr);
    	Console.WriteLine();
    
    	var expr = Person.GetFilterExpression("ivan").Unwrap();
    	Console.WriteLine("Unwrapped: " + expr);
    	Console.WriteLine();
    
    	var persons = context.Persons.Where(Person.GetFilterExpression("ivan").Unwrap());
    	Console.WriteLine("SQL Query 1: " + persons);
    	Console.WriteLine();
    
    	var companies = context.Companies.Where(x => x.Persons.Any(Person.GetFilterExpression("abc").Wrap())).Unwrap(); // here we use .Wrap method without parameters, because .Persons is the ICollection (not IQueryable) and we can't pass Expression<Func<T, bool>> as Func<T, bool>, so we need it for successful compilation. Unwrap method expand Wrap method usage and convert Expression to lambda function.
    	Console.WriteLine("SQL Query 2: " + companies);
    	Console.WriteLine();
    
    	var traceSql = persons.ToString();
    }
