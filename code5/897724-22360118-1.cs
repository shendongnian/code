    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Threading;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    
    
    namespace TextSendKeys
    {
        class Program
        {
    
            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            static extern bool SetForegroundWindow(IntPtr hWnd);
    
        static void Main(string[] args)
        {
            Process[] processes = Process.GetProcessesByName("process name here");
            Process game1 = processes[0];
    
            IntPtr p = game1.MainWindowHandle;
    
            SetForegroundWindow(p);
            SendKeys.SendWait("{1}");
            Thread.Sleep(1000);
            SendKeys.SendWait("{1}");
    
            }
        }
    }
