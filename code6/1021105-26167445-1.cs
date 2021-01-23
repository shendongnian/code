    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                _proc = HookCallback;
    
                _hookID = SetHook(_proc);
    
            }
    
            // This method is called for each global mouse event
            private IntPtr HookCallback(
                int nCode, IntPtr wParam, IntPtr lParam)
            {
                if (nCode >= 0 &&
                    MouseMessages.WM_LBUTTONDOWN == (MouseMessages)wParam)
                {
                    MSLLHOOKSTRUCT hookStruct = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));
                    if (isFirstClick)
                    {
                        firstClickMouseStruct = hookStruct;
                        label1.Text = "First click: " + hookStruct.pt.x + ", " + hookStruct.pt.y;
                    }
                    else
                    {
                        secondClickMouseStruct = hookStruct;
                        label2.Text = "Second click: " + secondClickMouseStruct.pt.x + ", " + secondClickMouseStruct.pt.y;
                        label3.Text = "Height: " + Math.Abs(secondClickMouseStruct.pt.y - firstClickMouseStruct.pt.y)
                            + ", Width: " + Math.Abs(secondClickMouseStruct.pt.x - firstClickMouseStruct.pt.x);
                    }
                    isFirstClick = !isFirstClick;
                }
                return CallNextHookEx(_hookID, nCode, wParam, lParam);
            }
    
            private MSLLHOOKSTRUCT firstClickMouseStruct;
            private MSLLHOOKSTRUCT secondClickMouseStruct;
            private bool isFirstClick = true;
        
            private LowLevelMouseProc _proc = null;
            private IntPtr _hookID = IntPtr.Zero;
    
            private IntPtr SetHook(LowLevelMouseProc proc)
            {
                using (Process curProcess = Process.GetCurrentProcess())
                using (ProcessModule curModule = curProcess.MainModule)
                {
                    return SetWindowsHookEx(WH_MOUSE_LL, proc,
                        GetModuleHandle(curModule.ModuleName), 0);
                }
            }
    
            private delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);
    
            private const int WH_MOUSE_LL = 14;
    
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
            private struct POINT
            {
                public int x;
                public int y;
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
    
            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern IntPtr SetWindowsHookEx(int idHook,
                LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);
    
            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool UnhookWindowsHookEx(IntPtr hhk);
    
            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
                IntPtr wParam, IntPtr lParam);
    
            [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern IntPtr GetModuleHandle(string lpModuleName);
    
            private void Form1_FormClosed(object sender, FormClosedEventArgs e)
            {
                UnhookWindowsHookEx(_hookID);
            }
        }
    }
    
