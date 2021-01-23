	try
	{
		foreach (var item in listView1.SelectedItems) 
		{
			MessageBox.Show(item.ToString());
		}
		if (listView1.SelectedItems.Count == 1)
		{
			var result = string.Format("Item: {0} || Position: {1} || Total Items: {2}", 
                listView1.SelectedItems[0], listView1.SelectedItems.Count, listView1.Items.Count);
			MessageBox.Show(result, "ListView Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	}
	catch (Exception ex)
	{
		MessageBox.Show("Select a Item");
		MessageBox.Show(ex.Message);
	}
