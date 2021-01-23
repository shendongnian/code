    private void OnKeyDown(object sender, KeyEventArgs e)
    {
    	if (e.Key.Equals(Key.Enter))
    	{
    		var txtBox = sender as TextBox;
    		var index = txtBox.TabIndex;
    
    		var nextTextBox = ContentPanel.Children.Cast<TextBox>().FirstOrDefault(t => t.TabIndex == index + 1);
    
    		if (nextTextBox != null)
    		{
    			nextTextBox.Focus();
    		}
    	}
    }
