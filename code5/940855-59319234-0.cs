        [StructLayout(LayoutKind.Sequential)]
        internal class SECURITY_ATTRIBUTES {
        #if !SILVERLIGHT
            // We don't support ACL's on Silverlight nor on CoreSystem builds in our API's.  
            // But, we need P/Invokes to occasionally take these as parameters.  We can pass null.
            public int nLength = 12;
            public SafeLocalMemHandle lpSecurityDescriptor = new SafeLocalMemHandle(IntPtr.Zero, false);
            public bool bInheritHandle = false;
        #endif // !SILVERLIGHT
        }
