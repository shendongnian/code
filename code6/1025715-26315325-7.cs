    private void cb_addPage_Click(object sender, EventArgs e)
    {
        string title = "TabPage " + (tabControl1.TabCount + 1).ToString();
        TabPage myTabPage = new TabPage(title);
        tabControl1.TabPages.Add(myTabPage);
        tabControl1.SelectedTab = myTabPage;
    }
    private void cb_removePage_Click(object sender, EventArgs e)
    {
        tabControl1.TabPages.Remove(tabControl1.SelectedTab);
    }
    private void Form1_Load(object sender, EventArgs e)
    {
        cb_addPage.Top = tabControl1.Top;
        cb_addPage.Left = tabControl1.Right - cb_addPage.Width;
        cb_removePage.Top = tabControl1.Top;
        cb_removePage.Left = cb_addPage.Left - cb_removePage.Width;
    }
