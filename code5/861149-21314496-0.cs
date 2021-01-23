    private class MouseDownFilter : IMessageFilter {
      public event EventHandler FormClicked;
      private int WM_LBUTTONDOWN = 0x201;
      private Form form = null;
      [DllImport("user32.dll")]
      public static extern bool IsChild(IntPtr hWndParent, IntPtr hWnd);
      public MouseDownFilter(Form f) {
        form = f;
      }
      public bool PreFilterMessage(ref Message m) {
        if (m.Msg == WM_LBUTTONDOWN) {
          if (Form.ActiveForm != null && Form.ActiveForm.Equals(form)) {
            OnFormClicked();
          }
        }
        return false;
      }
      protected void OnFormClicked() {
        if (FormClicked != null) {
          FormClicked(form, EventArgs.Empty);
        }
      }
    }
