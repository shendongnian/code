    protected void btnHidePanel_Click(object sender, EventArgs e)
            {
                Panel1.Visible = false;
                btnHidePanel.Visible = false;
                btnShowPanel.Visible = true;
            }
    
            protected void btnShowPanel_Click(object sender, EventArgs e)
            {
                Panel1.Visible = true;
                Panel1.GroupingText = "This Legend Text Has been Changed";
                btnHidePanel.Visible = true;
                btnShowPanel.Visible = false;
            }
