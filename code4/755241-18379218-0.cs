        [DllImport("User32.dll",
                   EntryPoint = "mouse_event",
                   CallingConvention = CallingConvention.Winapi)]
        internal static extern void Mouse_Event(int dwFlags,
                                                int dx,
                                                int dy,
                                                int dwData,
                                                int dwExtraInfo);
    
       ...
    
       // Move mouse cursor to an absolute position to_x, to_y
       int to_x = 500;
       int to_y = 300;
       
       // Mickey X coordinate
       int mic_x = (int) System.Math.Round(to_x * 65536.0 / ScreenWidth);
       // Mickey Y coordinate
       int mic_y = (int) System.Math.Round(to_y * 65536.0 / ScreenHeight);
    
       // 0x0001 | 0x8000: Move + Absolute position
       Mouse_Event(0x0001 | 0x8000, mic_x, mic_y, 0, 0);
