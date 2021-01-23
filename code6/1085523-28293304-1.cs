    using System;
    using System.Runtime.InteropServices;
    
    namespace Win32DllClient
    {
    
        class Program
        {
            [DllImport("UsbComm.dll", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
            public static extern bool Usb_Init(out IntPtr hwnd);
            static void Main(string[] args)
            {
                   IntPtr hwnd = new IntPtr(0);
                   var ret = Usb_Init(out hwnd);
            }
        }
    }
