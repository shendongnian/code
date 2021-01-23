    using System.Web;
    public myClass
    {
    	private static bool dllIsLoaded = false;
    	
    	[DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    	[return: MarshalAs(UnmanagedType.Bool)]
    	static extern bool SetDllDirectory(string lpPathName);
    	
    	public void myDllLoader()
    	{
    		if (!dllIsLoaded)
    		{
    #if DEBUG
    			string dllDir = Path.Combine(HttpRuntime.AppDomainAppPath, @"Lib\Debug\");
    #else
    			string dllDir = Path.Combine(HttpRuntime.AppDomainAppPath, @"Lib\Release\");
    #endif
    			SetDllDirectory(dllDir);
    			 // Call any function in your DLL to load it.  Stays loaded for the duration of the app.
    			string ver = myDllGetVersion();
    			SetDllDirectory("");	// Reset path to original
    			dllIsLoaded = true;
    		}
    	}
    }
