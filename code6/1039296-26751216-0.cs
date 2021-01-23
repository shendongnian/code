		private static void TestEnumExtension<T>(T enm)
		{
				Type[] types = {enm.GetType()};
				MethodInfo method = typeof(Extension).GetMethod("ToStringEnum", BindingFlags.Public | BindingFlags.Static, null, types, null);
				Console.WriteLine(method.Invoke(null, new object[] {enm}));
		}
