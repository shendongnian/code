    // If child form closed, remove tabPage.
    private void ActiveMdiChild_FormClosed(object sender, FormClosedEventArgs e)
    {
        ((sender as Form).Tag as TabPage).Dispose();
    }
    private void mdiTabControl_SelectedIndexChanged(object sender, EventArgs e)
    {
        if ((mdiTabControl.SelectedTab != null) && 
             (mdiTabControl.SelectedTab.Tag != null))
        {
            this.BeginUpdate();
            (mdiTabControl.SelectedTab.Tag as Form).Select();
            this.EndUpdate();
        }
    }
    
