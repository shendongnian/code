    using Microsoft.Win32;
    using System;
    using System.Diagnostics.Contracts;
    using System.Runtime.InteropServices;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            const int HWND_BROADCAST = 0xffff;
            const uint WM_SETTINGCHANGE = 0x001a;
    
            [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
            static extern bool SendNotifyMessage(IntPtr hWnd, uint Msg, 
                UIntPtr wParam, string lParam);
            
            static void Main(string[] args)
            {
                using (var envKey = Registry.LocalMachine.OpenSubKey(
                    @"SYSTEM\CurrentControlSet\Control\Session Manager\Environment",
                    true))
                {
                    Contract.Assert(envKey != null, @"registry key is missing!");
                    envKey.SetValue("TEST1", "TestValue");
                    SendNotifyMessage((IntPtr)HWND_BROADCAST, WM_SETTINGCHANGE,
                        (UIntPtr)0, "Environment");
                }
            }
        }
    }
