    ....
    foreach (ListItem listItem in itemsToAdd)
    {
    	if (lstBoxToUserProjects.Items.Contains(listItem)) listItem.IsDuplicate = true;
    	lstBoxToUserProjects.Items.Add(listItem);
    }
    ....
