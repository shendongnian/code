    public static readonly unsafe memcpyimplDelegate memcpyimpl =
        (memcpyimplDelegate)Delegate.CreateDelegate(
            typeof(memcpyimplDelegate),
            typeof(Buffer).GetMethod("memcpyimpl",
                BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
         ?? typeof(Buffer).GetMethod("Memcpy",
                BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic,
                null, new Type[] { typeof(byte*), typeof(byte*), typeof(int) }, null)
         );
