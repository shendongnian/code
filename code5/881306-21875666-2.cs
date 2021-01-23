    private void MainForm_MdiChildActivate(object sender, EventArgs e)
    {
        if (this.ActiveMdiChild == null)
            mdiTabControl.Visible = false; // If no child forms, hide tabControl
        else
        {
            // Child form always maximized.
            this.ActiveMdiChild.WindowState = FormWindowState.Maximized; 
            // If child form is new and has no tabPage, create new tabPage.
            if (this.ActiveMdiChild.Tag == null)
            {
                // Add a tabPage to tabControl with child form caption
                TabPage tp = new TabPage(this.ActiveMdiChild.Text);
                tp.Tag = this.ActiveMdiChild;
                tp.Parent = mdiTabControl;
                mdiTabControl.SelectedTab = tp;
                this.ActiveMdiChild.Tag = tp;
                this.ActiveMdiChild.FormClosed += new FormClosedEventHandler(ActiveMdiChild_FormClosed);
            }
            // Make visible if required.
            if (!mdiTabControl.Visible) 
                mdiTabControl.Visible = true;
        }
    }
    
