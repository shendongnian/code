    [DllExport("funcName", CallingConvention.Cdecl)]
    public static int funcName(string par1, string par2, IntPtr par3, IntPtr par4) 
    {
        string inputStr = Marshal.PtrToStringAnsi(par3);
        string outputStr = "foo\0";
        byte[] outputBytes = Encoding.Default.GetBytes(outputStr);
        Marshal.Copy(outputBytes, 0, par3, outputBytes.Length);
        return 0; 
    }
