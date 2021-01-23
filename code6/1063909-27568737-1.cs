    private string formText = string.Empty;
    protected override void WndProc(ref Message m) {
      if (m.Msg == 0x0112) {
        if (m.WParam == new IntPtr(0xF030)) {
          formText = this.Text;
          this.Text = string.Empty;
        } else {
          this.Text = formText;
        }
      }
      base.WndProc(ref m);
    }
