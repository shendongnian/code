    private void btnaddtab_Click(object sender, EventArgs e)
            {
                TabPage newTp = new TabPage();
                WebBrowser newWB = new WebBrowser();
                newWB.Name = "Page" + tabControl1.TabPages.Count + 1;
                newWB.Dock = DockStyle.Fill;
                newWB.Url = new Uri(@"http://www.bing.com");
                newTp.Controls.Add(newWB);
                tabControl1.TabPages.Add(newTp);   
            }
    
            private void btnback_Click(object sender, EventArgs e)
            {
                (tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0] as WebBrowser).GoBack();
            }
    
            private void btnforward_Click(object sender, EventArgs e)
            {
                (tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0] as WebBrowser).GoForward();
            }
