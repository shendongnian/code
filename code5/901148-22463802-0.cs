    if (dr == DialogResult.Yes)
    {
        if (this.tabControl1.SelectedTab == tabPage2)
        {
            for (int i = 0; i < tabPage2.Controls.Count; i++)
            {
                tabPage2.Controls[i].Text = "";
            }
        }
    }
