    public void AddNewTab()
    {
        UserControl1 myUserControl = new UserControl1();
        myUserControl.Dock = DockStyle.Fill;
        TabPage myTabPage = new TabPage();//Create new tabpage
        myTabPage.Controls.Add(myUserControl);
        tabControl1.TabPages.Add(myTabPage);           
    }
