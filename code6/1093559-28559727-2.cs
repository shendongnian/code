    [DllExport("GetInformationEx", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
    public static int GetInformationEx([MarshalAs(UnmanagedType.AnsiBStr)] out string strout, int length)
    {
        int returnLength = length;
        try
        {
            string info = _setupInformation.ToString();
            if (info.Length < 1000) 
            {
                returnLength = info.Length;   
            }
            strout = info.Substring(0, returnLength);
        }
        catch 
        {
            strout = "";
            returnLength = 0;
        }
        return returnLength; 
    }
