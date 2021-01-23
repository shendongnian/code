    using System;
    using System.Runtime.InteropServices;
    using System.Threading;
    
    namespace s26244308
    {
        class Program
        {
            static void Main(string[] args)
            {
                bool keepGoing = true;
    
                while (keepGoing)
                {
                    int wasItPressed = SysWin32.GetAsyncKeyState(SysWin32.VK_ESCAPE);
                    if (wasItPressed != 0)
                    {
                        keepGoing = false;  // stop
                        continue;
                    }
    
                    // for this sample: just loop a few letters
                    for (int x = 0x41; x <= 0x4A; x++)
                    {
                        int letterPressed = SysWin32.GetAsyncKeyState(x);
                        if (letterPressed != 0)
                        {
                            // now check for a few other keys
                            int shiftAction = SysWin32.GetAsyncKeyState(SysWin32.VK_SHIFT);
                            int ctrlAction = SysWin32.GetAsyncKeyState(SysWin32.VK_CONTROL);
                            int altAction = SysWin32.GetAsyncKeyState(SysWin32.VK_MENU);
    
                            // format my output
                            string letter = string.Format("Letter: {0} ({1})", Convert.ToChar(x), KeyAction(letterPressed));
                            string shift = string.Format("Shift: {0}", KeyAction(shiftAction));
                            string ctrl = string.Format("Control: {0}", KeyAction(ctrlAction));
                            string alt = string.Format("Alt: {0}", KeyAction(altAction));
    
                            Console.WriteLine("{0,-20}{1,-18}{2,-18}{3,-18}", letter, shift, ctrl, alt);
                            break;
                        }
                    }
                    Thread.Sleep(10);
                }
    
                Console.WriteLine("-- Press Any Key to Continue --");
                Console.ReadLine();
            }
    
            private static string KeyAction(int pressed)
            {
                if (pressed == 0)
                    return "Up";
    
                // check LSB
                if (IsBitSet(pressed, 0))
                    return "Pressed";
    
                // checked MSB
                if (IsBitSet(pressed, 15))
                    return "Down";
    
                return Convert.ToString(pressed, 2);
            }
            private static bool IsBitSet(int b, int pos)
            {
                return (b & (1 << pos)) != 0;
            }
        }
    
        class SysWin32
        {
            public const int VK_ESCAPE = 0x1B;
            public const int VK_SHIFT = 0x10;
            public const int VK_CONTROL = 0x11;
            public const int VK_MENU = 0x12;
    
            [DllImport("user32.dll")]
            public static extern int GetAsyncKeyState(Int32 i);
        }
    
    }
