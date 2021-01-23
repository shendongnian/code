    [ComVisible(true)]
    [Guid("BE55747F-FEA9-4C1F-A103-32A00B162DF0")]
    [ClassInterface(ClassInterfaceType.AutoDual)]
    public class Test
    {
        //[return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_BSTR)]
        public string[] GetStringArray()
        {
            var a = new string[3];
            a[0] = "string0";
            a[1] = null;
            a[2] = "string2";
            return a;
        }
    
    }
