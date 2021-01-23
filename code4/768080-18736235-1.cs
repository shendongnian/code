    private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
    {
        // "First Tab Page" is the text of the tab page.
        if ((sender as TabControl).SelectedTab.Text == "First Tab Page")
        {
            string filecontents = File.ReadAllText(@"path\to\configFile.txt");
            textBox1.Text = filecontents;
        }
    }
