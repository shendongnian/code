    [DllImport("User32.Dll")]
    public static extern long SetCursorPos(int x, int y);
    private void button1_Click(object sender, EventArgs e)
    {
        SetCursorPos(50,50);
    }
