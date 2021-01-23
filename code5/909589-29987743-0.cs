    [StructLayout(LayoutKind.Sequential)]
    public struct INPUT
    {
        public SendInputEventType type;
        public KeybdInputUnion mkhi;
    }
    [StructLayout(LayoutKind.Explicit)]
    public struct KeybdInputUnion
    {
        [FieldOffset(0)]
        public KEYBDINPUT ki;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct KEYBDINPUT
    {
        public ushort wVk;
        public ushort wScan;
        public uint dwFlags;
        public uint time;
        public IntPtr dwExtraInfo;
    }
    public enum SendInputEventType : int
    {
        InputKeyboard
    }
    public enum KeyCode : ushort
    {
        /// <summary>
        /// Right shift
        /// </summary>
        RSHIFT = 0xa1,
        /// <summary>
        /// Shift key
        /// </summary>
        SHIFT = 0x10,
        /// <summary>
        /// Right control
        /// </summary>
        RCONTROL = 0xa3,
        /// <summary>
        /// Left control
        /// </summary>
        LCONTROL = 0xa2,
        /// <summary>
        /// Left shift
        /// </summary>
        LSHIFT = 160,
        /// <summary>
        /// Ctlr key
        /// </summary>
        CONTROL = 0x11,
        /// <summary>
        /// Alt key
        /// </summary>
        ALT = 18,
    }
    
    [DllImport("User32.dll", SetLastError = true)]
    static extern uint SendInput(uint nInputs, ref INPUT pInputs, int cbSize);
    void YourMethodHereLikeTimerTickOrWE()
    {
        if (Control.ModifierKeys == Keys.Shift)
        {
            SendKeyUp(KeyCode.SHIFT);
        } 
        if (Control.ModifierKeys == Keys.Alt)
        {
            SendKeyUp(KeyCode.ALT);
        }
        if (Control.ModifierKeys == Keys.Control)
        {
            SendKeyUp(KeyCode.CONTROL);
        }
        if (Control.ModifierKeys == (Keys.Control | Keys.Shift))
        {
            SendKeyUp(KeyCode.CONTROL);
            SendKeyUp(KeyCode.SHIFT);
        }
        if (Control.ModifierKeys == (Keys.Control | Keys.Alt))
        {
            SendKeyUp(KeyCode.CONTROL);
            SendKeyUp(KeyCode.ALT);
        }
        if (Control.ModifierKeys == (Keys.Alt | Keys.Shift))
        {
            SendKeyUp(KeyCode.ALT);
            SendKeyUp(KeyCode.SHIFT);
        }
        if (Control.ModifierKeys == (Keys.Alt | Keys.Shift | Keys.Control))
        {
            SendKeyUp(KeyCode.ALT);
            SendKeyUp(KeyCode.SHIFT);
            SendKeyUp(KeyCode.CONTROL);
        }
    }
    public static void SendKeyUp(KeyCode keyCode)
    {
        INPUT input = new INPUT
        {
            type = SendInputEventType.InputKeyboard,
        };
        input.mkhi.ki = new KEYBDINPUT();
        input.mkhi.ki.wVk = (ushort)keyCode;
        input.mkhi.ki.wScan = 0;
        input.mkhi.ki.dwFlags = 2;
        input.mkhi.ki.time = 0;
        input.mkhi.ki.dwExtraInfo = IntPtr.Zero;
        //INPUT[] inputs = new INPUT[] { input };
        if (SendInput(1, ref input, Marshal.SizeOf(typeof(INPUT))) == 0)
            throw new Exception();
     }
