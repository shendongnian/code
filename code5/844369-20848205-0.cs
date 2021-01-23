    // Create some collection to store the IDs
    List<string> itemsToDelete = new List<string>();
    // Loop through all of the items, check if the box 
    // is checked, add to list if it is
    foreach (ListViewItem item in yourListView.Items)
    {
        CheckBox chkDelete = (CheckBox)item.FindControl("chkDelete");
        if(chkDelete.Checked)
        {
            string yourID = item.DataItem["id"].ToString();
            itemsToDelete.Add(yourID);
        }
    }
