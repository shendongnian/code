    [DllImport("user32.dll",EntryPoint="FindWindow")]
    private static extern IntPtr FindWindow(string sClass, string sWindow);
    
    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool SetForegroundWindow(IntPtr hWnd);
    IntPtr notepadHwnd = FindWindow("Notepad",(string)null);
    if (notepadHwnd == null)
    {
      System.Diagnostics.Process notepad = new Process();
      notepad.StartInfo.FileName = "notepad.exe";
      notepad.Start();
      System.Threading.Thread.Sleep(500);
      notepadHwnd = FindWindow("Notepad",(string)null);
    }
    // get the text from the users input
    string msg = textBox1.Text;
    if (notepadHwnd != null)
    {    
       SetForgroundWindow(notepadHwnd);
       // Send the string to the application that has focus 
       SendKeys.Send(msg);
    }
