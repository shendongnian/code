	var selected = listBox.SelectedItem;
	if (!string.IsNullOrWhiteSpace(selected.ToString()))
	{
		//Remove it
		listBox.Items.Remove(selected);
	}
