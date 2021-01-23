    public static class Importer
    {
    
        [DllImport("ChatLib.dll", EntryPoint = "LogMain", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.LPStr)]
        public static extern string LogMain();
    }
    
    public static void main(String args[])
    {
        string s = Importer.LogMain();
    }
    
