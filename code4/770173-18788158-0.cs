	using System;
	using System.Collections.Generic;
	class TestClass
	{
		public void TestMethod<T>(out T something)
		{
			something = default(T);
		}
	}
	static class Program
	{
		static void Main()
		{
			var method = typeof(TestClass).GetMethod("TestMethod");
			var parameter = method.GetParameters()[0];
			Console.WriteLine("parameter.ParameterType.IsGenericParameter: " + parameter.ParameterType.IsGenericParameter);
			Console.WriteLine("parameter.ParameterType.IsByRef: " + parameter.ParameterType.IsByRef);
			Console.WriteLine("parameter.ParameterType.GetElementType().IsGenericParameter: " + parameter.ParameterType.GetElementType().IsGenericParameter);
		}
	}
