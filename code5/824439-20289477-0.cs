    public const int WM_NCLBUTTONDOWN = 0xA1;
    public const int HT_CAPTION = 0x2;
    [DllImportAttribute("user32.dll")]
    public static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
    [DllImportAttribute("user32.dll")]
    public static extern bool ReleaseCapture();        
    public void mouseMove(MouseEventArgs e) 
    {
       if (e.Button == System.Windows.Forms.MouseButtons.Left)
       {
          ReleaseCapture();
          SendMessage(this.Handle,  WM_NCLBUTTONDOWN, new IntPtr(HT_CAPTION), IntPtr.Zero);
       }
    }
