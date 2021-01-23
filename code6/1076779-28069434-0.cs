    [DllImport("libc.so.6")]
    private static extern int execl(
    	[MarshalAs(UnmanagedType.LPTStr)] string path, 
    	[MarshalAs(UnmanagedType.LPTStr)] string argv);
    
    public static void Main()
    {
    	execl("/usr/bin/bash", string.Empty);
    }
