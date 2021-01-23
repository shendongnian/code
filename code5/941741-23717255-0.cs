    protected override void WndProc(ref Message m) {
        if (m.Msg == 0x10) {
            if (MessageBox.Show("Do you really want to exit?", "Exit Game", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
        }
        base.WndProc(ref m);
    }
