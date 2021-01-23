    void Main()
    {
    	var mw = new MainW();
    	mw.Show();
    	
    	var hWnd = FindWindowByCaption(IntPtr.Zero, "testwindow");
    	var rootVisual = System.Windows.Interop.HwndSource.FromHwnd(hWnd).RootVisual;
    	MainW m2 = (MainW)rootVisual;
    	Thread.Sleep(500);
    	m2.Title="is going";
    	Thread.Sleep(500);
    	m2.Title="to close...";
    	Thread.Sleep(500);
    	m2.Close();
    }
    
    [System.Runtime.InteropServices.DllImportAttribute("user32.dll", EntryPoint="FindWindow", SetLastError = true)]
    static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);
    
    class MainW: System.Windows.Window
    {
        public MainW()
        {
          Title = "testwindow";
          Width = 230;
          Height = 100;
          Background = System.Windows.Media.Brushes.AliceBlue;
    	}
    }
