    private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
    	var indexOfMatchedItem = -1;
    	foreach (var item in listView1.Items)
    	{
    		if (item.ToString() == textBox1.Text)
    		{
    			indexOfMatchedItem = listView1.Items.IndexOf(item);
    			break;
    		}
    	}
    	if (indexOfMatchedItem != -1) 
    	{
    		listView1.SelectedItems.Clear();
    		listView1.SelectedIndex = indexOfMatchedItem;
    	}	
    }
