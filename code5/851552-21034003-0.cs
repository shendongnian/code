    public class ListEx : ListBox {
      private const int WM_LBUTTONDOWN = 0x201;
      protected override void WndProc(ref System.Windows.Forms.Message m) {
        if (m.Msg == WM_LBUTTONDOWN) {
          Point pt = new Point(m.LParam.ToInt32());
          if (this.IndexFromPoint(pt) == -1) {
            return;
          }
        }
        base.WndProc(ref m);
      }
    }
