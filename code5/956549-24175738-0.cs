    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    
    using System.Text;
    
    namespace ConsoleApplication4
    {
        class Program
        {
            [DllImport("User32.dll", EntryPoint = "FindWindow")]
            public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
    
            [DllImport("user32.dll")]
    
            [return: MarshalAs(UnmanagedType.Bool)]
    
            static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);
    
            [StructLayout(LayoutKind.Sequential)]
    
            public struct RECT
            {
    
                public int Left; 
    
                public int Top; 
    
                public int Right; 
    
                public int Bottom; 
    
            }
    
            static void Main(string[] args)
            {
                string WinTitle = ""; //windows title
                IntPtr awin = FindWindow(null, WinTitle);
                if (awin != IntPtr.Zero)
                {
                    RECT rc = new RECT();
    
                    GetWindowRect(awin, ref rc);
    
                    int width = rc.Right - rc.Left; 
    
                    int height = rc.Bottom - rc.Top; 
    
                    int x = rc.Left;
    
                    int y = rc.Top;
    
                    Console.WriteLine(string.Format("width:{0} height:{1} left:{2} top:{3}", width, height, x, y));
                }
                else
                {
                    Console.WriteLine("can not find the window");
                }
            }
        }
    }
