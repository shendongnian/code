    using System;
    using System.Linq.Expressions;
    public class Program
	{
		public static void Main()
		{
			string myString = "My Hello string variable";
			
            // Prints "myString : My Hello String Variable
			Console.WriteLine("{0} : {1}", GetVariableName(() => myString), myString);
		}
		
		public static string GetVariableName<T>(Expression<Func<T>> expr)
		{
			var body = (MemberExpression)expr.Body;
	
			return body.Member.Name;
		}
	}
