    public void getItemsFromTextBox(TextBox textbox)
    {
    	Items = new List<string>();
    	string[] lines = textbox.Text.Split('\n');
    	foreach (string item in lines)
    	{
    		if (!String.IsNullOrWhiteSpace(item))
    			Items.Add(item);
    	}
    }
