    [DllImport(DllPath, CallingConvention = CallingConvention.Cdecl)]
    private static extern int get_lib_version(ref IntPtr version);
    public static string GetLibVersion()
    {
      var ptrVersion = IntPtr.Zero;
      get_lib_version(ref ptrVersion);
      var version = Marshal.PtrToStringAnsi(ptrVersion);
      return version;
    }
