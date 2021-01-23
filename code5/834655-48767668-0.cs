    //make tabs invisible (so you wont see them changing)
    private void HideAllTabsOnTabControl(TabControl theTabControl)
    {
    	theTabControl.Appearance = TabAppearance.FlatButtons;
    	theTabControl.ItemSize = new Size(0, 1);
    	theTabControl.SizeMode = TabSizeMode.Fixed;
    }
    
    //hide all tabs
    private void hide_all_tabs() {
    	Tab_content.TabPages.Remove(tabPage1);
    	Tab_content.TabPages.Remove(tabPage2);
    	Tab_content.TabPages.Remove(tabPage3);
    	Tab_content.TabPages.Remove(tabPage4);
    }
    private void materiałyQCToolStripMenuItem_Click(object sender, EventArgs e)
    {
    	hide_all_tabs(); //hide everything
    	Tab_content.TabPages.Add(tabPage1); //schow just first tab
    }
    private void analizatoryQCToolStripMenuItem_Click(object sender, EventArgs e)
    {
    	hide_all_tabs();
    	Tab_content.TabPages.Add(tabPage2);
    }
    private void QCzDzisiajToolStripMenuItem_Click(object sender, EventArgs e)
    {
    	hide_all_tabs();
    	Tab_content.TabPages.Add(tabPage3);
    }
    private void standlabToolStripMenuItem_Click(object sender, EventArgs e)
    {
    	hide_all_tabs();
    	Tab_content.TabPages.Add(tabPage4);
    }
