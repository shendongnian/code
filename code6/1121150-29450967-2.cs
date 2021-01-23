    protected void ddlWeek_SelectedIndexChanged(object sender, EventArgs e)
    {
        lbWeek.Text = "You selected the week of: " + ddlWeek.SelectedItem.Text + "<br/>";
        lbWeek.Text += "Value: " + ddlWeek.SelectedItem.Value + "<br/>";
        int liStartIndex = ddlWeek.SelectedItem.Value.IndexOf(":") + 1;
        int liLength = ddlWeek.SelectedItem.Value.Length - liStartIndex;
        string lsOriginalValue = string.Empty;
        if (liStartIndex > 1)
        {
            lsOriginalValue = ddlWeek.SelectedItem.Value.Substring(liStartIndex, liLength);
            lbWeek.Text += "Original Value: " + lsOriginalValue;
        }
    }
