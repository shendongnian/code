    [ComImport, Guid("809C652E-7396-11D2-9771-00A0C9B4D50C")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [CoClass(typeof(CorMetaDataDispenser))]
    interface IMetaDataDispenser
    {
        uint OpenScope([MarshalAs(UnmanagedType.LPWStr)]string szScope, uint dwOpenFlags, ref Guid riid, [MarshalAs(UnmanagedType.Interface)] out object ppIUnk);
        // interface also contains 2 irrelevant methods
    }
    
    [ComImport, Guid("E5CB7A31-7512-11D2-89CE-0080C792E5D8")]
    class CorMetaDataDispenser
    {
    }
