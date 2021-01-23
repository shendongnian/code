    [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("0002E000-0000-0000-C000-000000000046")]
    public interface IEnumGUID
    {
        [PreserveSig]
        int Next(int celt, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex=0)] Guid[] rgelt, out int pceltFetched);
        [PreserveSig]
        int Skip(int celt);
        [PreserveSig]
        int Reset();
        void Clone(out IEnumGUID ppenum);
    }
