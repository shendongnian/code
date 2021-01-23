    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace UnRestrict.Forms
    {
    
        static class Sounds
        {
            //hexidecimal values for the values needed
            private const int VOLUP = 0xA0000;
            private const int VOLDOWN = 0x90000;
            private const int VOLMUTE = 0x80000;
            private const int APPCMND = 0x319;
    
            [DllImport("user32.dll")]
            public static extern IntPtr SendMessageW(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
    
            public static void VolumeUp()
            {
                int val = (Int32)SendMessageW(Process.GetCurrentProcess().Handle, APPCMND, Process.GetCurrentProcess().Handle, (IntPtr)VOLUP);
            }
    
            public static void VolumeDown()
            {
                SendMessageW(Process.GetCurrentProcess().Handle, APPCMND, Process.GetCurrentProcess().Handle, (IntPtr)VOLDOWN);
            }
    
            public static void VolumeMute()
            {
                SendMessageW(Process.GetCurrentProcess().Handle, APPCMND, Process.GetCurrentProcess().Handle, (IntPtr)VOLMUTE);
            }
    
        }
    }
