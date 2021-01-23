    AutoCompleteBox box = new AutoCompleteBox();
    box.Text = textField.Value ?? "";
    if (textField.Proposals != null)
    {
    	box.ItemsSource = textField.Proposals;
    	box.FilterMode = AutoCompleteFilterMode.None;
    	box.GotFocus += (sender, args) =>
    		{
    			if (string.IsNullOrEmpty(box.Text))
    			{
    				box.Text = " ";
    			}
    			box.Dispatcher.BeginInvoke(() => box.IsDropDownOpen = true);
    		};
    	box.LostFocus += (sender, args) =>
    		{
    			box.Text = box.Text.Trim();
    		};
    	box.TextChanged += (sender, args) =>
    		{
    			if (!string.IsNullOrWhiteSpace(box.Text) &&
    				box.FilterMode != AutoCompleteFilterMode.Contains)
    			{
    				box.FilterMode = AutoCompleteFilterMode.Contains;
    			}
    
    			if (string.IsNullOrWhiteSpace(box.Text) &&
    				box.FilterMode != AutoCompleteFilterMode.None)
    			{
    				box.FilterMode = AutoCompleteFilterMode.None;
    			}
    		};
    }
