    private void btnadd_Click(object sender, EventArgs e)
    {
        UserControl1 usr = new UserControl1();
        pnlUI.SuspendLayout();
        // check if there's already content in the panel, if so, keep a reference.
        if (pnlUI.Controls.Count > 0)
        {
            _previousPanelContent = pnlUI.Controls[0];
            pnlUI.Controls.Clear();
        }
        
        pnlUI.Controls.Add(usr);
        pnlUI.ResumeLayout(false);
    }
