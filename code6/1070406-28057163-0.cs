    private void btnadd_Click(object sender, EventArgs e)
    {
        //This is not accessible outside the callback function.
        UserControl1 usr = new UserControl1();
    
        pnlUI.SuspendLayout();
        pnlUI.Controls.Clear();
        pnlUI.Controls.Add(usr);
        pnlUI.ResumeLayout(false);
    }
