	private static readonly Action<IntPtr, object, int, int> _copyToManaged =
		GetCopyToManagedMethod();
	private static Action<IntPtr, object, int, int> GetCopyToManagedMethod()
	{
		var method = typeof(Marshal).GetMethod("CopyToManaged",
			System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);
		return (Action<IntPtr, object, int, int>)method.CreateDelegate(
			typeof(Action<IntPtr, object, int, int>), null);
	}
	public static void Copy<T>(IntPtr source, T[] destination, int startIndex, int length)
		where T : struct
	{
		_copyToManaged(source, destination, startIndex, length);
	}
