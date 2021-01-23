	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Linq.Expressions;
	using System.Reflection;
	public class Program
	{
		public static void Main(string[] args)
		{
			// test non static method with result
			string test = "Test String";
			MethodInfo method = typeof(string).GetMethod("Substring", BindingFlags.Public | BindingFlags.Instance, null, new Type[]{typeof(int)},null);
			Func<object[], object> lazyMethod = CreateLazyMethodWithResult(test, method);
			object result = lazyMethod(new object[] { 5 });
			Console.WriteLine(result);
			Console.WriteLine();
			
			// test static method with no result
			var staticMethod = typeof(Program).GetMethod("StaticMethod", BindingFlags.Static | BindingFlags.Public);
			var staticAction = CreateLazyStaticMethodWithNoResult(staticMethod);
			
			staticAction(new object[]{"Test message"});
			Console.WriteLine();
			
			//test static method with result
			var staticMethodWithResult = typeof(Program).GetMethod("StaticMethodWithResult", BindingFlags.Static | BindingFlags.Public);
			var staticActionWithResult = CreateLazyStaticMethodWithResult(staticMethodWithResult);
			
			Console.WriteLine(staticActionWithResult(new object[] { "Test message" }));
			Console.WriteLine();
			
			// sample with constructor
			var constructorCall = typeof(TestClass).GetConstructors().First();
			var constructorAction = GenerateLazyConstructorCall(constructorCall);
			
			var createdObject = constructorAction(new object[] { "Test message" });
			
			Console.WriteLine("Created type is " + createdObject.GetType().FullName);
		}
		
		//Test class
		public class TestClass
		{
			public TestClass(string message)
			{
				Console.WriteLine("----Constructor is called with message - " + message);
			}
		}
		
		public static void StaticMethod(string message)
		{
			Console.WriteLine("----Static method is called with " + message);
		}
		
		public static string StaticMethodWithResult(string message)
		{
			Console.WriteLine("----Static method with result is called with " + message);
			return "Hello from static method";
		}
		
		public static Func<object[], object> CreateLazyMethodWithResult(object instance, MethodInfo method)
		{
			ParameterExpression allParameters;
			var methodCall = GenerateCallExpression(instance, method, out allParameters);
			var lambda = Expression.Lambda<Func<object[], object>>(methodCall, allParameters);
			return lambda.Compile();
		}
		
		public static Action<object[]> CreateLazyMethodWithNoResult(object instance, MethodInfo method)
		{
			ParameterExpression allParameters;
			var methodCall = GenerateCallExpression(instance, method, out allParameters);
			var lambda = Expression.Lambda<Action<object[]>>(methodCall, allParameters);
			return lambda.Compile();
		}
		
		public static Func<object[], object> CreateLazyStaticMethodWithResult(MethodInfo method)
		{
			ParameterExpression allParameters;
			var methodCall = GenerateCallExpression(null, method, out allParameters);
			var lambda = Expression.Lambda<Func<object[], object>>(methodCall, allParameters);
			return lambda.Compile();
		}
		
		public static Action<object[]> CreateLazyStaticMethodWithNoResult(MethodInfo method)
		{
			ParameterExpression allParameters;
			var methodCall = GenerateCallExpression(null, method, out allParameters);
			var lambda = Expression.Lambda<Action<object[]>>(methodCall, allParameters);
			return lambda.Compile();
		}
		
		
		/// <summary>
		/// Generate expression call
		/// </summary>
		/// <param name="instance">If instance is NULL, then it method will be treated as static method</param>
		private static MethodCallExpression GenerateCallExpression(object instance, MethodBase method, out ParameterExpression allParameters)
		{
			var parameters = GenerateParameters(method, out allParameters);
			
			var methodInfo = method as MethodInfo;
			// it's non static method
			if (instance != null)
			{
				var instanceExpr = Expression.Convert(Expression.Constant(instance), instance.GetType());
				return Expression.Call(instanceExpr, methodInfo, parameters.ToArray());
			}
			
			// it's static method
			return Expression.Call(methodInfo, parameters.ToArray());
		}
		
		public static Func<object[], object> GenerateLazyConstructorCall(ConstructorInfo constructor)
		{
			ParameterExpression allParameters;
			var parameters = GenerateParameters(constructor, out allParameters);
			
			var newExpr = Expression.New(constructor, parameters.ToArray());
			var lambda = Expression.Lambda<Func<object[], object>>(newExpr, allParameters);
			
			return lambda.Compile();
		}
		
		private static List<Expression> GenerateParameters(MethodBase method, out ParameterExpression allParameters)
		{
			allParameters = Expression.Parameter(typeof(object[]), "params");
			ParameterInfo[] methodMarameters = method.GetParameters();
			List<Expression> parameters = new List<Expression>();
			for (int i = 0; i < methodMarameters.Length; i++)
			{
				var indexExpr = Expression.Constant(i);
				var item = Expression.ArrayIndex(allParameters, indexExpr);
				var converted = Expression.Convert(item, methodMarameters[i].ParameterType);
				parameters.Add(converted);
			}
			
			return parameters;
		}
	}
