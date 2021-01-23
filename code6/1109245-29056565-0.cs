	try
	{
		foreach (var item in listView1.SelectedItems) 
		{
			MessageBox.Show(item.ToString());
		}
		if (listView1.SelectedItems.Count == 1)
		{
			var item = listView1.SelectedItems[0];
			var result = "Item: " + item + " || Position: 0 || Total Items: 1";
			MessageBox.Show(result, "ListView Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	}
	catch (Exception ex)
	{
		MessageBox.Show("Select a Item");
		MessageBox.Show(ex.Message);
	}
