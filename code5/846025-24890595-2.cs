    using System;
    using System.Diagnostics;
    using Microsoft.Win32;
    using System.Runtime.InteropServices;
    using System.Threading;
    
    namespace CSharpTesting
    {
        class Program
        {
            /// <summary>
            /// The window is initially visible. See http://msdn.microsoft.com/en-gb/library/windows/desktop/ms632600(v=vs.85).aspx.
            /// </summary>
            public const UInt32 WS_VISIBLE  = 0X94000000;
            /// <summary>
            /// Specifies we wish to retrieve window styles.
            /// </summary>
            public const int GWL_STYLE = -16;
    
            [DllImport("user32.dll")]
            public static extern IntPtr FindWindow(String sClassName, String sAppName);
    
            [DllImport("user32.dll", SetLastError = true)]
            static extern UInt32 GetWindowLong(IntPtr hWnd, int nIndex);
    
            static void Main(string[] args)
            {
                // Crappy loop to poll window state.
                while (true)
                {
                    if (IsKeyboardVisible())
                    {
                        Console.WriteLine("keyboard is visible");
                    }
                    else
                    {
                        Console.WriteLine("keyboard is NOT visible");
                    }
    
                    Thread.Sleep(1000);
                }
            }
    
            /// <summary>
            /// Gets the window handler for the virtual keyboard.
            /// </summary>
            /// <returns>The handle.</returns>
            public static IntPtr GetKeyboardWindowHandle()
            {
                return FindWindow("IPTip_Main_Window", null);
            }
    
            /// <summary>
            /// Checks to see if the virtual keyboard is visible.
            /// </summary>
            /// <returns>True if visible.</returns>
            public static bool IsKeyboardVisible()
            {
                IntPtr keyboardHandle = GetKeyboardWindowHandle();
    
                bool visible = false;
    
                if (keyboardHandle != IntPtr.Zero)
                {
                    UInt32 style = GetWindowLong(keyboardHandle, GWL_STYLE);
                    visible = (style == WS_VISIBLE);
                }
    
                return visible;
            }
        }
    }
