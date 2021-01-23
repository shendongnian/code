    public class WindowHandle : IWin32Window
    {
    
      public IntPtr Handle { get; private set; }
    
      public WindowHandle(IntPtr handle)
      {
        Handle = handle;
      }
    
    }
    
    private void ShowMessageBox_Click(object sender, EventArgs e)
    {
      var process = Process.GetProcessesByName("explorer").FirstOrDefault();
      var window = new WindowHandle(process.MainWindowHandle);
    
      MessageBox.Show(window, "Hello World");   
    }
