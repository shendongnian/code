    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct IscKeyValue
    {
        public string ParamName;
        public string ParamValue;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct IscKvParamList
    {
        public IscKeyValue[] DataItems;
        public int Len;
    }
