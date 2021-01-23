    private static string GetKeyboardLayout()
    {
        var layout = new StringBuilder();
        var buffer = new StringBuilder(64);
        for (int i = 0; i < 6; i++)
        {
            int scanCode = 0x10 + i;
            int lParam = scanCode << 16;
            GetKeyNameText(lParam, buffer, buffer.Capacity);
            layout.Append(buffer.ToString());
        }
        return layout.ToString();
    }
    
    [DllImport("user32.dll")]
    private static extern int GetKeyNameText(int lParam, StringBuilder lpString, int cchSize);
