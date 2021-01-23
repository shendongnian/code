    public struct Sample
    {
        [MarshalAs(UnmanagedType.BStr)]
        public string Name;
    }
    [DllExport]
    public static int func(
        [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex=1)]
        Sample[] samples, 
        ref int len
    )
    {
        // len holds the length of the array on input
        // len is assigned the number of items that have been assigned values 
        // use the return value to indicate success or failure
        for (int i = 0; i < len; i++)
            samples[i].Name = "foo: " + i.ToString();
        return 0;
    }
