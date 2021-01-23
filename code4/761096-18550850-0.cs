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
			TypeHelper<Program>.Copy(prog1, prog2);
		}
	}
	public static class TypeHelper<T> where T : class
	{
		public delegate void CopyAction(T from, T to);
		public static readonly CopyAction Copy = new Converter<Type, CopyAction>(t =>
		{
			var method = new DynamicMethod(string.Empty, null, new Type[] { t, t }, t);
			var gen = method.GetILGenerator();
			foreach (var field in t.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
			{
				gen.Emit(OpCodes.Ldarg_1);
				gen.Emit(OpCodes.Ldarg_0);
				gen.Emit(OpCodes.Ldfld, field);
				gen.Emit(OpCodes.Stfld, field);
			}
			return (CopyAction)method.CreateDelegate(typeof(CopyAction));
		})(typeof(T));
	}
