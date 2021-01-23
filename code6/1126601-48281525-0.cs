    private void OnRequestBringIntoView(object sender, RequestBringIntoViewEventArgs e)
    {
    	//Allows the keyboard to bring the items into view as expected:
    	if (Keyboard.IsKeyDown(Key.Down) || Keyboard.IsKeyDown(Key.Up))
    		return;
    	// Allows to bring the selected item into view:
    	if (((ComboBoxItem)e.TargetObject).Content == list.SelectedItem)
    		return;
    
    	e.Handled = true;
    }
