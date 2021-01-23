    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    
    public class Program
    {
    	public static void Main()
    	{
    		Criteria c = new Criteria() { 
                Property = "Name", 
                Operator = "==", 
                Value = "Foo" };
    		
    		var queryable = (new List<Receipt>() { 
    			new Receipt { Name = "Foo", Amount = 1 },
    			new Receipt { Name = "Foo", Amount = 2 }, 
    			new Receipt { Name = "Bar" }  
    		}).AsQueryable();
    		
    		var parameter = Expression.Parameter(typeof(Receipt), "x");
    		var property = Expression.Property(parameter, typeof(Receipt).GetProperty(c.Property));
    		var constant = Expression.Constant(c.Value);
    		var operation = Expression.Equal(property, constant);
    		var expression = Expression.Call(
    			typeof(Queryable),
    			"Where",
    			new Type[] { queryable.ElementType },
    			queryable.Expression, 
    			Expression.Lambda<Func<Receipt, bool>>(operation, new ParameterExpression[] { parameter })
    		);
    		
    		Console.WriteLine("Linq Expression: {0} \n", expression.ToString());
    		Console.WriteLine("Results: \n");
    		
    		var results = queryable.Provider.CreateQuery<Receipt>(expression);
    		foreach(var r in results)
    		{
    			Console.WriteLine("{0}:{1}", r.Name, r.Amount);
    		}
    	}
    }
    
    public class Criteria
    {
    	public string Property, Operator, Value;
    }
    
    public class ReceiptDetail
    {
    	public string ItemName;
    }
    
    public class Receipt
    {
    	public string Name { get; set; }
    	public int Amount;
    	public ICollection<ReceiptDetail> Details;
    }
