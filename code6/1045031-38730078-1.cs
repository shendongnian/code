    static class Program
    {
    	static Mutex mutex = new Mutex(true, guid());
    	static string guid()
    	{
    		// http://stackoverflow.com/questions/502303/how-do-i-programmatically-get-the-guid-of-an-application-in-net2-0
    		Assembly assembly = Assembly.GetExecutingAssembly();
    		var attribute = (GuidAttribute)assembly.GetCustomAttributes(typeof(GuidAttribute), true)[0];
    		return attribute.Value;
    	}
    
    	static int MainWindowHandle
    	{
    		get
    		{
    			return Settings.Default.hwnd;
    		}
    		set
    		{
    			Settings sett = Settings.Default;
    			sett.hwnd = value;
    			sett.Save();
    		}
    	}
    	public static string GetFileName()
    	{
    		ActivationArguments a = AppDomain.CurrentDomain.SetupInformation.ActivationArguments;
    		// aangeklikt bestand achterhalen
    		string[] args = a == null ? null : a.ActivationData;
    		return args == null ? "" : args[0];
    	}
    
    	[STAThread]
    	static void Main()
    	{
    		if (mutex.WaitOne(TimeSpan.Zero, true))
    		{
    			#region standaard
    			Application.EnableVisualStyles();
    			Application.SetCompatibleTextRenderingDefault(false);
    			#endregion
    			#region Culture instellen
    			string cult = CultureInfo.CurrentCulture.Name;
    			Thread.CurrentThread.CurrentUICulture = new CultureInfo(cult);
    			Thread.CurrentThread.CurrentCulture = new CultureInfo(cult);
    			#endregion
    			MainForm frm = new MainForm();
    			MainWindowHandle = (int)frm.Handle;
    			Application.Run(frm);
    			MainWindowHandle = 0;
    			mutex.ReleaseMutex();
    		}
    		else
    		{
    			int hwnd = 0;
    			while (hwnd == 0)
    			{
    				Thread.Sleep(600);
    				hwnd = MainWindowHandle;
    			}
    			if (hwnd != 0)
    			{
    				Win32.CopyDataStruct cds = new Win32.CopyDataStruct();
    				try
    				{
    					string data = GetFileName();
    					cds.cbData = (data.Length + 1) * 2; // number of bytes
    					cds.lpData = Win32.LocalAlloc(0x40, cds.cbData); // known local-pointer in RAM
    					Marshal.Copy(data.ToCharArray(), 0, cds.lpData, data.Length); // Copy data to preserved local-pointer
    					cds.dwData = (IntPtr)1;
    					Win32.SendMessage((IntPtr)hwnd, Win32.WM_COPYDATA, IntPtr.Zero, ref cds);
    				}
    				finally
    				{
    					cds.Dispose();
    				}
    			}
    		}
    	}
    }
