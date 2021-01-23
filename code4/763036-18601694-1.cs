	private void listBox1.SelectedIndexChanged(object sender,EventArgs e)
	{
		string item ;
		
		item = listBox1.SelectedItem.ToString();
		if(item.EndsWith(".folder"))
		{
			//it's a .folder, raise the event or react as needed
		}
	}
