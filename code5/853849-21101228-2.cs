    //Temporarly list to keep created tabs
    List<TabPage> tempPages = new List<TabPage>(); 
    private void Form2_Load(object sender, EventArgs e)
    {
        comboBox1.Items.Add("tabPage2");
        comboBox1.Items.Add("tabPage3");
    }
    public void RemoveTabs()
    {
        //Remove all tabs in tempPages if there are any
        if (tempPages != null)
        {
            foreach (var page in tempPages)
            {
                tabControl1.TabPages.Remove(page);
            }
            tempPages.Clear();
        }
    }
    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (comboBox1.SelectedIndex >= 0)
        {
            RemoveTabs();
            var newTabName = ((ComboBox)sender).SelectedItem.ToString();
            var newtab = new TabPage(newTabName);
            //Create the new tabPage 
            tabControl1.TabPages.Add(newtab);
            //Add the newly created tab to the tempPages list
            tempPages.Add(newtab);
        }
    }
