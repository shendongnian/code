    using System;
    using System.Runtime.InteropServices;
    using System.Threading;
    namespace pressand_hold
    {
        internal class Program
        {
            internal enum ScanCodeShort : short
            {
                KEY_0 = 48,
                KEY_1,
                KEY_2,
                KEY_3,
                KEY_4,
                KEY_5,
                KEY_6,
                KEY_7,
                KEY_8,
                KEY_9,
                KEY_A = 65,
                KEY_B,
                KEY_C,
                KEY_D,
                KEY_E,
                KEY_F,
                KEY_G,
                KEY_H,
                KEY_I,
                KEY_J,
                KEY_K,
                KEY_L,
                KEY_M,
                KEY_N,
                KEY_O,
                KEY_P,
                KEY_Q,
                KEY_R,
                KEY_S,
                KEY_T,
                KEY_U,
                KEY_V,
                KEY_W,
                KEY_X,
                KEY_Y,
                KEY_Z,
            }
            [DllImport("user32.dll")]
            public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);
            private static void Main(string[] args)
            {
                Thread.Sleep(2000);
                keybd_event((byte)ScanCodeShort.KEY_V, 0x45, 0, 0);
                Console.WriteLine("done");
                Console.Read();
            }
        }
    }
