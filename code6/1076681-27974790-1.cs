    private ListViewItem CurrentItemSelected {get;set;}
    ......
    
    public void SourcesListView_SelectedIndexChanged(object sender, EventArgs e)
    {
        ListView.SelectedListViewItemCollection selectedRows = remoteSourceListView.SelectedItems;
    
        foreach (ListViewItem row in selectedRows)
        {
            sourceNameTextBox.Text = row.SubItems[1].Text;
            sourceUrlTextBox.Text = row.SubItems[2].Text;
    
            CurrentItemSelected = row;
    
            if (row.SubItems[3].Text != "")
            {
                sourceBranchTextBox.Enabled = true;
                sourceBranchTextBox.Text = row.SubItems[3].Text;
            }
        }
    }
    public void SourceName_TextChanged(object sender, EventArgs e)
    {
        if(CurrentItemSelected != null)
            CurrentItemSelected.SubItems[1].Text = sourceNameTextBox.Text;
    }
