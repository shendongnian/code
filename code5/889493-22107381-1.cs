    public partial class Form1 : Form, IMessageFilter {
      [DllImport("user32.dll")]
      private static extern IntPtr WindowFromPoint(Point pt);
      [DllImport("user32.dll")]
      private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
      public Form1() {
        InitializeComponent();
        Application.AddMessageFilter(this);
      }
      public bool PreFilterMessage(ref Message m) {
        if (m.Msg == 0x20a) {
          Point pos = new Point(m.LParam.ToInt32());
          IntPtr hWnd = WindowFromPoint(pos);
          if (hWnd != IntPtr.Zero && hWnd != m.HWnd && Control.FromHandle(hWnd) != null) {
            SendMessage(hWnd, m.Msg, m.WParam, m.LParam);
            return true;
          }
        }
        return false;
      }
    }
