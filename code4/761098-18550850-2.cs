	using System;
	using System.Reflection;
	using System.Reflection.Emit;
	public class Program
	{
		private int a;
		private static void Main()
		{
			var prog1 = new Program() { a = 1 };
			var prog2 = new Program() { a = 2 };
			TypeHelper<Program, Program>.Copy(prog1, prog2);
		}
	}
	public static class TypeHelper<T1, T2> where T1 : class where T2: class
	{
		public delegate void CopyAction(T1 from, T2 to);
		public static readonly CopyAction Copy = new Converter<Type, CopyAction>(t1 =>
		{
			var method = new DynamicMethod(string.Empty, null, new Type[] { t1, typeof(T2) }, t1, true);
			var gen = method.GetILGenerator();
			foreach (var field in t1.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
			{
				gen.Emit(OpCodes.Ldarg_1);
				gen.Emit(OpCodes.Ldarg_0);
				gen.Emit(OpCodes.Ldfld, field);
				gen.Emit(OpCodes.Stfld, typeof(T2).GetField(field.Name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			}
			return (CopyAction)method.CreateDelegate(typeof(CopyAction));
		})(typeof(T1));
	}
