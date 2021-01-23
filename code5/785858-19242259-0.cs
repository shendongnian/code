        [DllImport("user32.dll")]
        public static extern int FindWindow(string lpClassName,string lpWindowName);
        [DllImport("user32.dll")]
        public static extern int SendMessage(int hWnd, uint Msg, int wParam, int lParam);
            
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_CLOSE = 0xF060;
        int iHandle = FindWindow("#32770", "Choose File to Upload");
        if (iHandle > 0)
        {
              // close the window using API        
              SendMessage(iHandle, WM_SYSCOMMAND, SC_CLOSE, 0);
        }
