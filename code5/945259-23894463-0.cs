        private void Form1_Load(object sender, EventArgs e)
        {
            SelectTabByTitle("xtraTabPage3",xtraTabControl1);
        }
        private void SelectTabByTitle(String tabTitle, XtraTabControl tabControl)
        {
            if (tabControl != null)
            {
                XtraTabPage pageToSelect = (from curPage in tabControl.TabPages
                                            where curPage.Text == tabTitle
                                            select curPage).FirstOrDefault();
                if (pageToSelect != null)
                {
                    tabControl.SelectedTabPage = pageToSelect;
                }
            }
        }
