    public struct test
    {
        GetUID_Delegate API_GetUID;
        GetChipType_Delegate API_GetChipType;
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        delegate void GetUID_Delegate(IntPtr pData, uint dataLen);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        delegate uint GetChipType_Delegate();
    } 
    [DllImport(@"GDevice.dll")]
    public static extern void GetAPIObject(ref test test_a);
    test a = new test();
    GetAPIObject(ref a);
    uint chipType = a.API_GetChipType();
