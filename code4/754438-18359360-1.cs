	public static class ExchangeEnumImpl<T>
	{
		public delegate T dImpl(ref T location, T value);
		public static readonly dImpl Impl = CreateExchangeImpl();
		static dImpl CreateExchangeImpl()
		{
			var underlyingType = Enum.GetUnderlyingType(typeof(T));
			var dynamicMethod = new DynamicMethod(string.Empty, typeof(T), new[] { typeof(T).MakeByRefType(), typeof(T) }, typeof(dImpl).Module, true);
			var ilGenerator = dynamicMethod.GetILGenerator();
			ilGenerator.Emit(OpCodes.Ldarg_0);
			ilGenerator.Emit(OpCodes.Ldarg_1);
			ilGenerator.Emit(OpCodes.Call, typeof(Interlocked).GetMethod("Exchange", BindingFlags.Static | BindingFlags.Public, null, new[] { underlyingType.MakeByRefType(), underlyingType }, null));
			ilGenerator.Emit(OpCodes.Ret);
			return (dImpl)dynamicMethod.CreateDelegate(typeof(dImpl));
		}
	}
	public static T ExchangeEnum<T>(ref T location, T value)
	{
		return ExchangeEnumImpl<T>.Impl(ref location, value);
	}
