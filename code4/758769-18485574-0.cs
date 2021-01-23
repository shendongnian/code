	[System.Runtime.CompilerServices.MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetCurrentNamespace()
	{
		return System.Reflection.Assembly.GetCallingAssembly().EntryPoint.DeclaringType.Namespace;
	}
