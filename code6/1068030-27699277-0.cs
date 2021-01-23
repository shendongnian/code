    private void signInToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var si = new SignIn();
        si.MdiParent = this;
        si.Dock = DockStyle.Fill;
        si.FormClosed += delegate
                         {
                             if (si.IsUserAuthenticated)
                             {
                                 yourLoginItem.Enabled = false;
                                 yourLogoutItem.Enabled = true;
                             };
                         }
        si.Show();
    }
