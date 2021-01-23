    [ComImport, Guid("...)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [SuppressUnmanagedCodeSecurity]
    public interface IFoo
    {
        [PreserveSig] int Bar(); // Calling this is OK
        [PreserveSig] int Foo(); // Calling this should also be OK
    }
