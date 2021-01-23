	[DllImport("kernel32.dll", SetLastError = false)]
	static extern void CopyMemory(IntPtr destination, IntPtr source, UIntPtr length);
	public static void Copy<T>(IntPtr source, T[] destination, int startIndex, int length)
		where T : struct
	{
		var gch = GCHandle.Alloc(destination, GCHandleType.Pinned);
		try
		{
			var targetPtr = Marshal.UnsafeAddrOfPinnedArrayElement(destination, startIndex);
			var bytesToCopy = Marshal.SizeOf(typeof(T)) * length;
			CopyMemory(targetPtr, source, (UIntPtr)bytesToCopy);
		}
		finally
		{
			gch.Free();
		}
	}
