    private bool AreThereAnyEmptyTextBoxes()
    {
    	foreach (var item in this.Controls)
    	{
    		if (item is TextBox)
    		{
    			var textBox = (TextBox)item;
    			if (textBox.Text == string.Empty)
    			{
    				return true;
    			}
    		}
    	}
    
    	return false;
    }
