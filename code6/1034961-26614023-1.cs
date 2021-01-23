	using System;
	using System.Linq.Expressions;
	using System.Reflection;
	using System.Collections.Generic;
						
	public class Program
	{
		public static void Main()
		{
			string test = "Test Long String";
			// get SubString method with one parameter
			var method = typeof(string).GetMethod("Substring", BindingFlags.Public | BindingFlags.Instance, null, new Type[]{typeof(int)},null);
			
			Func<object[], object> lazyMethod = CreateLazyMethod(test, method);
			
			// call it like "Test Long String".SubString(5);
			object result = lazyMethod(new object[] { 5 });		
			Console.WriteLine(result);
		}
		
		public static Func<object[], object> CreateLazyMethod(object instance, MethodInfo method)
		{
			var allParameters = Expression.Parameter(typeof(object[]), "params");
			ParameterInfo[] methodParameters = method.GetParameters();
			List<Expression> parameters = new List<Expression>();
			for (int i = 0; i < methodParameters.Length; i++)
			{
				var indexExpr = Expression.Constant(i);
				var item = Expression.ArrayIndex(allParameters, indexExpr);
				var converted = Expression.Convert(item, methodParameters[i].ParameterType);
				parameters.Add(converted);
			}
			
			var instanceExpr = Expression.Convert(Expression.Constant(instance), instance.GetType());
			var methodCall = Expression.Call(instanceExpr, method, parameters.ToArray());
			var lambda = Expression.Lambda<Func<object[], object>>(methodCall, allParameters);
			var func = lambda.Compile();
			
			return func;
		}
	}
