    private int explorerWindowNumber;
    public const int WM_SYSCOMMAND = 0x0112;
    public const int SC_MINIMIZE = 0xF020;
    [DllImport("user32.dll", SetLastError = true)]
    public static extern int GetForegroundWindow();
    [DllImport("user32.dll")]
    public static extern int SendMessage(int hWnd, uint Msg, int wParam, int lParam);
    public void button1_Click(object sender, EventArgs e)
    {
        //Start my window
        StartMyExplorer();
    }
    private void StartMyExplorer()
    {
        Process.Start("D:\\");
        Thread.Sleep(1000);
        //Get the window id (int)
        explorerWindowNumber = GetForegroundWindow();
    }
    private void button2_Click(object sender, EventArgs e)
    {
        //Minimize the window i created
        SendMessage(explorerWindowNumber, WM_SYSCOMMAND, SC_MINIMIZE, 0);
    }
