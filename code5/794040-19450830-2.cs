     using System.Runtime.InteropServices;
    public class WindowHandling
    {
    	[DllImport("User32.dll")]
    	public static extern int SetForegroundWindow(IntPtr point);
    
    	public void ActivateTargetApplication(string processName, List<string> barcodesList)
    	{
    		Process p = Process.Start("notepad++.exe");
    		p.WaitForInputIdle();
    		IntPtr h = p.MainWindowHandle;
    		SetForegroundWindow(h);
    		SendKeys.SendWait("k");
    		IntPtr processFoundWindow = p.MainWindowHandle;
    	}
    }
