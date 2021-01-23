    [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2)]
    private char[] value1;
    public string Value1
    {
        get { return new string(this.value1); }
        set { this.value1 = value.ToCharArray(); }
    }
