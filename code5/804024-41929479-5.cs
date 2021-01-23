	[ComImport, SuppressUnmanagedCodeSecurity, Guid("c6646f0a-3d96-4ac2-9e3f-8ae2a11145ce")]
	[ClassInterface(ClassInterfaceType.None)]
	public abstract class _session
	{
	}
	public class session : _session, IMFAsyncCallback
	{
		HResult IMFAsyncCallback.GetParameters(out MFASync pdwFlags, out MFAsyncCallbackQueue pdwQueue)
		{
			/// add-on interfaces can use explicit implementation...
		}
		HResult IMFAsyncCallback.Invoke([In, MarshalAs(UnmanagedType.Interface)] IMFAsyncResult pAsyncResult)
		{
			/// ...or public.
		}
    }
