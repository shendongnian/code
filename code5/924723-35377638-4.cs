    static string GetCharsFromKeys(Keys keys, bool shift)    
    {
        var buf = new StringBuilder(256);
        var keyboardState = new byte[256];
        if (shift)
        {
            keyboardState[(int)Keys.ShiftKey] = 0xff;
        }
            ToUnicode((uint)keys, 0, keyboardState, buf, 256, 0);
            return buf.ToString();
    }
