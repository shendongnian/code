    internal class Utf8Marshaler : ICustomMarshaler
	{
		private static Utf8Marshaler _staticInstance;
		public IntPtr MarshalManagedToNative(object managedObj)
		{
			if (managedObj == null)
				return IntPtr.Zero;
			if (!(managedObj is string))
				throw new MarshalDirectiveException(
					"UTF8Marshaler must be used on a string.");
			// not null terminated
			byte[] strbuf = Encoding.UTF8.GetBytes((string) managedObj);
			IntPtr buffer = Marshal.AllocHGlobal(strbuf.Length+1);
			Marshal.Copy(strbuf, 0, buffer, strbuf.Length);
			// write the terminating null
			Marshal.WriteByte(buffer + strbuf.Length, 0);
			return buffer;
		}
		public object MarshalNativeToManaged(IntPtr pNativeData)
		{
			if (pNativeData == IntPtr.Zero)
				return string.Empty;
			int length = 1;
			IntPtr offsetPtr = IntPtr.Add(pNativeData, 1);
			while (Marshal.ReadByte(offsetPtr) != 0)
			{
				offsetPtr = IntPtr.Add(offsetPtr, 1);
				length++;
			}
			byte[] strbuf = new byte[length];
			Marshal.Copy(pNativeData, strbuf, 0, length);
			string data = Encoding.UTF8.GetString(strbuf);
			return data;
		}
		public void CleanUpNativeData(IntPtr pNativeData)
		{
			Marshal.FreeHGlobal(pNativeData);
		}
		public void CleanUpManagedData(object managedObj)
		{
		}
		public int GetNativeDataSize()
		{
			return -1;
		}
		public static ICustomMarshaler GetInstance(string cookie)
		{
			if (_staticInstance == null)
			{
				return _staticInstance = new Utf8Marshaler();
			}
			return _staticInstance;
		}
	}
