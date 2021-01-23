    using System;
	using System.Linq.Expressions;
					
	public class Program
	{
		public static void Main()
		{
			string myString = "test";
			
            // This will print "myVar : test"
			Method(myString);
		}
		
		public static void Method(string myVar)
		{
			Console.WriteLine("{0} : {1}", GetVariableName(() => myVar), myVar);
		}
		
		public static string GetVariableName<T>(Expression<Func<T>> expr)
		{
			var body = (MemberExpression)expr.Body;
	
			return body.Member.Name;
		}
	}
