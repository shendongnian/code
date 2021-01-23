	class MFSessionMarshaler : ICustomMarshaler
	{
		static ICustomMarshaler GetInstance(String _) => new MFSessionMarshaler();
		public Object MarshalNativeToManaged(IntPtr pUnk) => Marshal.GetTypedObjectForIUnknown(pUnk, typeof(session));
		public void CleanUpNativeData(IntPtr pNativeData) => Marshal.Release(pNativeData);
		public int GetNativeDataSize() => -1;
		IntPtr ICustomMarshaler.MarshalManagedToNative(Object _) => IntPtr.Zero;
		void ICustomMarshaler.CleanUpManagedData(Object ManagedObj) { }	}
