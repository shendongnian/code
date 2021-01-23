    [DllImport("user32.dll")]
    public static extern long SetCursorPos(int x, int y);
    public void SetCursorPosition(Point p)
    {
        SetCursorPos(p.X, p.Y);
    }
