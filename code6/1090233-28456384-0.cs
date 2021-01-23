    private void tabMain_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        if (tabMain.TabPages.Count > 0)
        {
            TabPage CurrentTab = tabMain.SelectedTab;
            tabMain.TabPages.Remove(CurrentTab);
            Form newWindow = new Form();
            foreach (Control ctrl in CurrentTab.Controls)
            {
                newWindow.Controls.Add(ctrl);
            }
            newWindow.Show();
        }
    }
