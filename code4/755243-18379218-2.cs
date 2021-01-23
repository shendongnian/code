        [DllImport("User32.dll",
                   EntryPoint = "mouse_event",
                   CallingConvention = CallingConvention.Winapi)]
        internal static extern void Mouse_Event(int dwFlags,
                                                int dx,
                                                int dy,
                                                int dwData,
                                                int dwExtraInfo);
        [DllImport("User32.dll",
                   EntryPoint = "GetSystemMetrics",
                   CallingConvention = CallingConvention.Winapi)]
        internal static extern int InternalGetSystemMetrics(int value);
    
       ...
    
       // Move mouse cursor to an absolute position to_x, to_y and make left button click:
       int to_x = 500;
       int to_y = 300;
       int screenWidth = InternalGetSystemMetrics(0);
       int screenHeight = InternalGetSystemMetrics(1);
       
       // Mickey X coordinate
       int mic_x = (int) System.Math.Round(to_x * 65536.0 / screenWidth);
       // Mickey Y coordinate
       int mic_y = (int) System.Math.Round(to_y * 65536.0 / screenHeight);
    
       // 0x0001 | 0x8000: Move + Absolute position
       Mouse_Event(0x0001 | 0x8000, mic_x, mic_y, 0, 0);
       // 0x0002: Left button down
       Mouse_Event(0x0002, mic_x, mic_y, 0, 0);
       // 0x0004: Left button up
       Mouse_Event(0x0004, mic_x, mic_y, 0, 0);
