	using System;
	using System.Linq.Expressions;
						
	public class Program
	{
		public static void Main()
		{
			var parent = new Parent()
			{
				Application = new Application()
				{
					ID = 42
				}
			};
			var val = GetValue(s => s.Application.ID, parent);
			
			Console.WriteLine("value is " + val);
		}
		
		public static T GetValue<T,S>(Expression<Func<S, T>> expression, S obj)
		{
			// here we compile expression to function
			Func<S,T> func = expression.Compile();
			// and execute it as delegate. 
			// it also can be cached to avoid often compilations
			var val = func(obj);
			return val;
		}
	}
	public class Parent
	{
		public Application Application {get;set;}
	}
	public class Application
	{
		public int ID {get;set;}
	}
