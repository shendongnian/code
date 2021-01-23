    public enum ACTION_TYPE : uint
    {
        NONE,  // 0
        RESTART, // 1.
        ABORT, // 2.
        WAIT //3
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct ACTIONS
    {
        public ACTION_TYPE type;
        public int delay;
    }
    [DllImport("NativeLibrary.dll", CallingConvention = CallingConvention.StdCall)]
    public static extern void testarray(ACTIONS[] actions, int len);
    var actions = new[] 
    {
        new ACTIONS { type = ACTION_TYPE.RESTART, delay = 11 },
        new ACTIONS { type = ACTION_TYPE.ABORT, delay = 22 },
        new ACTIONS { type = ACTION_TYPE.WAIT, delay = 33 },
    };
    testarray(actions, actions.Length);
