	using System;
	using System.Reflection.Emit;
	namespace Test774
	{
		class MainClass
		{
			public static void Main(string[] args)
			{
				var a = 666;
				DoWork(out a);
			}
			public static int DoWork(out int param)
			{
				var dynamicMethod = new DynamicMethod("ParameterExtractor", typeof(int), new [] { typeof(int).MakeByRefType() });
				var generator = dynamicMethod.GetILGenerator();
				generator.Emit(OpCodes.Ldarg_0);
				generator.Emit(OpCodes.Ldind_I4);
				generator.Emit(OpCodes.Ret);
				var parameterExtractor = (MethodWithTheOutParameter)dynamicMethod.CreateDelegate(typeof(MethodWithTheOutParameter), null);
				Console.WriteLine(parameterExtractor(out param));
				param = 1;
				return 0;
			}
			public delegate int MethodWithTheOutParameter(out int a);
		}
	}
