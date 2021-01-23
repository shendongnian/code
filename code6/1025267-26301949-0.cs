    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Windows.Forms;
    
    namespace Syracuse
    {
        public partial class Form1 : Form
        {
            private const int WH_MOUSE_LL = 14;
            private static LowLevelMouseProc _proc = HookCallback;
            private static IntPtr _hookID = IntPtr.Zero;
    
            public Form1()
            {
                InitializeComponent();
            }
    
            protected override void OnLoad(EventArgs e)
            {
                base.OnLoad(e);
                _hookID = SetHook(_proc);
            }
    
            protected override void OnClosed(EventArgs e)
            {
                base.OnClosed(e);
                UnhookWindowsHookEx(_hookID);
            }
    
            private void TimerOnTick(object sender, EventArgs e)
            {
                //left mouse button virtually down (obviously already is down the first loop)
                mouse_event(2, 0, 0, 0, UIntPtr.Zero);
    
                Thread.Sleep(100);
    
                //left mouse button virtually up
                mouse_event(4, 0, 0, 0, UIntPtr.Zero);
            }
    
    
            private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
            {
                if (nCode >= 0 && MouseMessages.WM_LBUTTONDOWN == (MouseMessages) wParam)
                {
                    var hookStruct = (MSLLHOOKSTRUCT) Marshal.PtrToStructure(lParam, typeof (MSLLHOOKSTRUCT));
                    Console.WriteLine(hookStruct.pt.x + ", " + hookStruct.pt.y + ", " + hookStruct.flags);
                }
    
                // Todo create OnMouseUpExEvent, OnMouseDownExEvent witch provide MSLLHOOKSTRUCT informations.
    
                return CallNextHookEx(_hookID, nCode, wParam, lParam);
            }
    
            private static IntPtr SetHook(LowLevelMouseProc proc)
            {
                using (var curProcess = Process.GetCurrentProcess())
                using (var curModule = curProcess.MainModule)
                {
                    return SetWindowsHookEx(WH_MOUSE_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
                }
            }
    
            private delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);
    
            #region Enum & Struct
            private enum MouseMessages
            {
                WM_LBUTTONDOWN = 0x0201,
                WM_LBUTTONUP = 0x0202,
                WM_MOUSEMOVE = 0x0200,
                WM_MOUSEWHEEL = 0x020A,
                WM_RBUTTONDOWN = 0x0204,
                WM_RBUTTONUP = 0x0205
            }
    
            [StructLayout(LayoutKind.Sequential)]
            private struct MSLLHOOKSTRUCT
            {
                public POINT pt;
                public uint mouseData;
                public uint flags;
                public uint time;
                public IntPtr dwExtraInfo;
            }
    
            [StructLayout(LayoutKind.Sequential)]
            private struct POINT
            {
                public int x;
                public int y;
            }
            #endregion
    
            #region Extern
            [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
            public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, UIntPtr dwExtraInfo);
    
            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);
    
            [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern IntPtr GetModuleHandle(string lpModuleName);
    
            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);
    
            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool UnhookWindowsHookEx(IntPtr hhk);
            #endregion
        }
    }
