    public void SourcesListView_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(remoteSourceListView.SelectedItems.Count > 0)
        {
            // With MultiSelect = false; there is only one selected item.
            CurrentItemSelected = remoteSourceListView.SelectedItems[0];
            sourceNameTextBox.Text = CurrentItemSelected.SubItems[1].Text;
            sourceUrlTextBox.Text = CurrentItemSelected.SubItems[2].Text;
            if (CurrentItemSelected.SubItems[3].Text != "")
            {
                sourceBranchTextBox.Enabled = true;
                sourceBranchTextBox.Text = CurrentItemSelected.SubItems[3].Text;
            }
        }
    }
