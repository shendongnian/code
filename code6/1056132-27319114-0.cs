    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    
    namespace SendKeysToProcess
    {
        class Program
        {
            [DllImport("user32.dll")]
            static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    
            static void Main(string[] args)
            {
                // Start Notepad process
                Process notepad = new Process();
                notepad.StartInfo.FileName = @"C:\Windows\Notepad.exe";
                notepad.Start();
    
                // Wait for notepad to start
                notepad.WaitForInputIdle();
    
                IntPtr p = notepad.MainWindowHandle;
                ShowWindow(p, 1);
                
                // Write some text to the Notepad window
                SendKeys.SendWait("Hello World!");
            }
        }
    }
