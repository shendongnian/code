    protected void btnCreateText_Click(object sender, EventArgs e)
    {
        var text = new TextBox();
        text.ID = "txtDynamic";
        plhControl.Controls.Add(text);
        
    }
    protected void btnRemoveText_Click(object sender, EventArgs e)
    {
        var text = new TextBox();
        text.ID = "txtDynamic";
        text.Visible = false;
    }
