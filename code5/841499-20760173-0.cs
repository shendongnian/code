    private bool addingPage = false;
    ....
     private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
     {
        if(!addingPage)
        {
            addingPage = true;
            TabPage tab = new TabPage("New Tab");
            tabControl1.TabPages.Insert(tabControl1.TabPages.Count - 1,tab);
            tabControl1.SelectedTab = tab;
            addingPage = false;
        }
     }
