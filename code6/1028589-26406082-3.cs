    using System;
    using System.Runtime.InteropServices;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            [StructLayout(LayoutKind.Sequential)]
            struct RECT
            {
                public int Left;
                public int Top;
                public int Right;
                public int Bottom;
            }
    
            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
            struct MONITORINFOEX
            {
                public int Size;
                public RECT Monitor;
                public RECT WorkArea;
                public uint Flags;
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
                public string DeviceName;
            }
    
            [DllImport("user32.dll", CharSet = CharSet.Unicode)]
            static extern bool GetMonitorInfo(IntPtr hMonitor, ref MONITORINFOEX lpmi);
    
            delegate bool MonitorEnumDelegate(IntPtr hMonitor, IntPtr hdcMonitor, ref RECT lprcMonitor, IntPtr dwData);
    
            [DllImport("user32.dll")]
            static extern bool EnumDisplayMonitors(IntPtr hdc, IntPtr lprcClip, MonitorEnumDelegate lpfnEnum, IntPtr dwData);
    
            static bool MonitorEnumProc(IntPtr hMonitor, IntPtr hdcMonitor, ref RECT lprcMonitor, IntPtr dwData)
            {
                MONITORINFOEX mi = new MONITORINFOEX();
                mi.Size = Marshal.SizeOf(typeof(MONITORINFOEX));
                if (GetMonitorInfo(hMonitor, ref mi))
                    Console.WriteLine(mi.DeviceName);
                return true;
            }
    
            static void Main(string[] args)
            {
                EnumDisplayMonitors(IntPtr.Zero, IntPtr.Zero, MonitorEnumProc, IntPtr.Zero);
            }
        }
    }
