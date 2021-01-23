    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    using System.Runtime.CompilerServices;
    using System.Diagnostics;
    
    
    namespace StackoverflowHooks
    {
        public partial class Form1 : Form
        {
            [DllImport("user32.dll")]
            private static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);
            [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern IntPtr GetModuleHandle(string lpModuleName);
            [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
            private static extern IntPtr CallNextHookEx(IntPtr hHook, int nCode, IntPtr wParam, IntPtr lParam);
    
   
            [StructLayout(LayoutKind.Sequential)]
            public struct KBDLLHOOKSTRUCT
            {
                public uint vkCode;
                public uint scanCode;
                public uint flags;
                public uint time;
                IntPtr dwExtraInfo;
            }
    
    
            IntPtr hHook;
            private delegate IntPtr HookProc(int nCode, IntPtr wp, IntPtr lp);
            HookProc lpfn;
    
            private IntPtr KeyboardHookProc(int code, IntPtr wParam, IntPtr lParam)
            {
                KBDLLHOOKSTRUCT data = (KBDLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(KBDLLHOOKSTRUCT));
                MessageBox.Show("Pressed key: " + (Keys)data.vkCode);
    
                return CallNextHookEx(hHook, code, wParam, lParam);
            }
    
    
            public Form1()
            {
                InitializeComponent();  
                SetHook();
            }
    
            private void SetHook()
            {
                int id_hook = 13; //WH_KEYBOARD_LL - HOOK
                lpfn = new HookProc(this.KeyboardHookProc);
                using (ProcessModule curModule = Process.GetCurrentProcess().MainModule)
                hHook = SetWindowsHookEx(id_hook, lpfn, GetModuleHandle(curModule.ModuleName), 0);
            }
        }
    }
