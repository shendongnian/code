    class Program
    {
        static void Main(string[] args)
        {
            Thread.Sleep(3000);
            int[] keyboardStrokes = { (int)Keys.LMenu, (int)Keys.Tab, (int)Keys.Tab };
            ProcessKey(keyboardStrokes);
            Console.Read();
        }
        struct INPUT
        {
            public INPUTType type;
            public INPUTUnion Event;
        }
        [StructLayout(LayoutKind.Explicit)]
        struct INPUTUnion
        {
            [FieldOffset(0)]
            internal MOUSEINPUT mi;
            [FieldOffset(0)]
            internal KEYBDINPUT ki;
            [FieldOffset(0)]
            internal HARDWAREINPUT hi;
        }
        [StructLayout(LayoutKind.Sequential)]
        struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public int mouseData;
            public int dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }
        [StructLayout(LayoutKind.Sequential)]
        struct KEYBDINPUT
        {
            public ushort wVk;
            public ushort wScan;
            public KEYEVENTF dwFlags;
            public int time;
            public IntPtr dwExtraInfo;
        }
        [StructLayout(LayoutKind.Sequential)]
        struct HARDWAREINPUT
        {
            public int uMsg;
            public short wParamL;
            public short wParamH;
        }
        enum INPUTType : uint
        {
            INPUT_KEYBOARD = 1
        }
        [Flags]
        enum KEYEVENTF : uint
        {
            EXTENDEDKEY = 0x0001,
            KEYUP = 0x0002,
            SCANCODE = 0x0008,
            UNICODE = 0x0004
        }
        [DllImport("user32.dll", SetLastError = true)]
        static extern UInt32 SendInput(int numberOfInputs, INPUT[] inputs, int sizeOfInputStructure);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        internal static extern uint MapVirtualKey(uint uCode, uint uMapType);
        private static void ProcessKey(int[] key)
        {
            INPUT[] inputs = new INPUT[key.Length + 1];
            for (int i = 0; i < key.Length; i++)
            {
                uint skey = MapVirtualKey((uint)key[i], (uint)0x0);
                inputs[i].type = INPUTType.INPUT_KEYBOARD;
                inputs[i].Event.ki.dwFlags = KEYEVENTF.SCANCODE;
                inputs[i].Event.ki.wScan = (ushort)skey;
            }
            inputs[key.Length].type = INPUTType.INPUT_KEYBOARD;
            inputs[key.Length].Event.ki.dwFlags = KEYEVENTF.UNICODE;
            inputs[key.Length].Event.ki.dwFlags |= KEYEVENTF.KEYUP;
            uint cSuccess = SendInput(inputs.Length, inputs, Marshal.SizeOf(typeof(INPUT)));
        }
    }
