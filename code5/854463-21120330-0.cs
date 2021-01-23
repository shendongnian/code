    private void tableLayoutPanel1_MouseClick(object sender, MouseEventArgs e) {
        foreach (Control ctl in tableLayoutPanel1.Controls) {
            if (ctl.Bounds.Contains(e.Location)) {
                ctl.Visible = true;
                break;
            }
        }
    }
