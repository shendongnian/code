    private bool onlyHideOnClose = true;
    private void FormMainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        if(this.onlyHideOnClose)
        {
            e.Cancel = true;
            this.WindowState = FormWindowState.Minimized;
        }
    }
    private void toolStripMenuItem1_Click(object sender, EventArgs e)
    {
        this.onlyHideOnClose = false;
        this.Close();
    }
