    List<TabPage> tempPages = new List<TabPage>(); 
    private void Form2_Load(object sender, EventArgs e)
    {
        comboBox1.Items.Add("tabPage2");
        comboBox1.Items.Add("tabPage3");
    }
    public void RemoveTabs()
    {
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
            tabControl1.TabPages.Add(newtab);
            tempPages.Add(newtab);
        }
    }
