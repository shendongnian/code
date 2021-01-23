    public struct test
    {
        IntPtr API_GetUID;
        IntPtr API_GetChipType;
    } 
    [DllImport(@"GDevice.dll")]
    public static extern void GetAPIObject(ref test test_a);
    delegate void GetUID_Delegate(IntPtr pData, uint dataLen);
    delegate uint GetChipType_Delegate();
    test a = new test();
    GetAPIObject(ref a);
    GetUID_Delegate getUID = Marshal.GetDelegateForFunctionPointer<GetUID_Delegate>(a.API_GetUID);
    GetChipType_Delegate getChipType = Marshal.GetDelegateForFunctionPointer<GetChipType_Delegate>(a.API_GetChipType);
    uint chipType = getChipType();
