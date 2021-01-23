    void OnMouseDoubleClick(object sender, MouseEventArgs e)
    {
    	var list = (ListBox)sender;
    
    	int itemIndex = list.IndexFromPoint(e.Location);
    	if (itemIndex != -1)
    	{
    		// This is your double clicked item
    		object item = list.Items[itemIndex];
    	}
    }
