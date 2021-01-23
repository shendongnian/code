    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Threading;
    
    namespace ConsoleApplication2
    {
        class Program
        {
    
            [DllImport("user32.dll", SetLastError = true)]
            static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
    
    
            [DllImport("user32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            static extern bool PostMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);
                
            private const int WM_CLOSE = 0x10;
    
            static void PostMessageSafe(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam)
            {
                bool returnValue = PostMessage(hWnd, msg, wParam, lParam);
                if (!returnValue)
                {
                    
                    Console.WriteLine("Some error occurred.");
    
                }
            }    
            static void Main()
            {
                
                var path = @"C:\deleteme\";
                Process.Start(path);
                
                Thread.Sleep(5000); // Give the folder some time to load within the OS
                IntPtr hWnd = FindWindow(null, "deleteme");
    
                if (hWnd != IntPtr.Zero)
                {
                    PostMessageSafe(hWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                    Console.Write("Success!\n");
                    Console.ReadLine();
                    
                }
                else
                {
                    Console.Write("Error Folder not found!\n");
                    Console.ReadLine();
                }
               
    
    
    
            }
        }
    }
