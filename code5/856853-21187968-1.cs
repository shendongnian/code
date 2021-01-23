    private void btn1_KeyDown(object sender, KeyEventArgs e)
    {
    
    	if (e.Key == Key.Tab && (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift)))
    	{
    		//do what you want when shift+tab is pressed.
    		e.Handled = true;
    	}
    	else
    	{
    		btn2.Focus();
    		e.Handled = true;
    	}
    	
    }
    
    private void btn2_KeyDown(object sender, KeyEventArgs e)
    {
    
    	if (e.Key == Key.Tab && (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift)))
    	{
    		//do what you want when shift+tab is pressed.
    		e.Handled = true;
    	}
    	else
    	{
    		btn1.Focus();
    		e.Handled = true;
    	}
    	
    }
