    public class MyHeader : Control {
      private const int WM_NCLBUTTONDOWN = 0xA1;
      private const int HT_CAPTION = 0x2;
      [DllImportAttribute("user32.dll")]
      private static extern int SendMessage(IntPtr hWnd, int Msg,
                                            int wParam, int lParam);
      [DllImportAttribute("user32.dll")]
      private static extern bool ReleaseCapture();
      protected override void OnMouseDown(MouseEventArgs e) {
        if (e.Button == MouseButtons.Left) {
          ReleaseCapture();
          SendMessage(this.FindForm().Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }
        base.OnMouseDown(e);
      }
    }
