    public static void SendCharUnicode(int utf32)
    {
    	string unicodeString = Char.ConvertFromUtf32(utf32);
    	Win32.INPUT[] input = new Win32.INPUT[unicodeString.Length];
    
    	for (int i = 0; i < input.Length; i++)
    	{
    		input[i] = new Win32.INPUT();
    		input[i].type = Win32.INPUT_KEYBOARD;
    		input[i].ki.wVk = 0;
    		input[i].ki.wScan = (short)unicodeString[i];
    		input[i].ki.time = 0;
    		input[i].ki.dwFlags = Win32.KEYEVENTF_UNICODE;
    		input[i].ki.dwExtraInfo = IntPtr.Zero;
    	}
    
    	Win32.SendInput((uint)input.Length, input, Marshal.SizeOf(typeof(Win32.INPUT)));
    }
