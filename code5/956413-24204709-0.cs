    public class PopupForm : Form
    {
      private const int WS_BORDER = 0x00800000;
      private const int WS_POPUP = unchecked((int)0x80000000);
      private const int WS_EX_TOPMOST = 0x00000008;
      private const int WS_EX_NOACTIVATE = 0x08000000;
      private const int WM_MOUSEACTIVATE = 0x0021;
      private const int MA_NOACTIVATEANDEAT = 4;
      private static readonly IntPtr HWND_TOPMOST = (IntPtr)(-1);
      private const int SWP_NOSIZE = 0x0001;
      private const int SWP_NOMOVE = 0x0002;
      private const int SWP_NOACTIVATE = 0x0010;
      [DllImport("user32.dll")]
      [return: MarshalAs(UnmanagedType.Bool)]
      private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter,
        int X, int Y, int cx, int cy, int uFlags);
      public PopupForm()
      {
        SetStyle(ControlStyles.Selectable, false);
        FormBorderStyle = FormBorderStyle.None;
        StartPosition = FormStartPosition.Manual;
        ShowInTaskbar = false;
        Visible = false;
      }
      protected override CreateParams CreateParams
      {
        get
        {
          CreateParams cp = base.CreateParams;
          cp.Style |= WS_POPUP | WS_BORDER;
          cp.ExStyle |= WS_EX_TOPMOST | WS_EX_NOACTIVATE;
          return cp;
        }
      }
      protected override bool ShowWithoutActivation
      {
        get { return true; }
      }
      protected override void WndProc(ref Message m)
      {
        if (m.Msg == WM_MOUSEACTIVATE)
        {
          OnClick(EventArgs.Empty);
          m.Result = (IntPtr)MA_NOACTIVATEANDEAT;
        }
        else
          base.WndProc(ref m);
      }
      public new void Show()
      {
        Windows.SetWindowPos(Handle, HWND_TOPMOST, 0, 0, 0, 0,
          SWP_NOACTIVATE | SWP_NOSIZE | SWP_NOMOVE);
        base.Show();
      }
    }
