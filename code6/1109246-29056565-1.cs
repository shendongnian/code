	try
	{
		foreach (var item in listView1.SelectedItems) 
		{
			MessageBox.Show(item.ToString());
		}
		if (listView1.SelectedItems.Count == 1)
		{
			var result = "Item: " + listView1.SelectedItems[0] + " || Position: " + listView1.SelectedItems.Count + " || Total Items: " + listView1.Items.Count.ToString();
			MessageBox.Show(result, "ListView Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	}
	catch (Exception ex)
	{
		MessageBox.Show("Select a Item");
		MessageBox.Show(ex.Message);
	}
