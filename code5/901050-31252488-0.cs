    [ComImport, Guid("PUT-GUID-HERE")]
    public interface IProdistLogger
    {
        [DispId(1000)]
        string Name { [return: MarshalAs(UnmanagedType.BStr)] get; }
        [DispId(1001)]
        void LogSimple (long level, [MarshalAs(UnmanagedType.BStr)] string message, object location);
    }
    [ComImport, Guid("PUT-GUID-HERE")]
    public interface IProdistLoggingHierarchy
    {
        [DispId(1000)]
        string Type { [return: MarshalAs(UnmanagedType.BStr)] get; }
        [DispId(1001)]
        IProdistLogger CreateLogger ([MarshalAs(UnmanagedType.BStr)] string name);
    }
    [ComImport, Guid("PUT-GUID-HERE")]
    public interface IProdistLogging
    {
        [DispId(1000)]
        IProdistLoggingHierarchy CreateHierarchy ([MarshalAs(UnmanagedType.BStr)] string type, object configuration);
    }
