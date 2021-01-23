	string message = null;
	TextBox focusMe = null;
	
	if (failure1)
	{
		message = "message1";
	}
	else if (failure2)
	{
		message = "message2";
	}
	else if (failure3)
	{
		message = "message3";
	}
	
	if (!string.IsNullOrEmpty(message))
	{
		MessageBox.Show(message);
		
		if (focusMe != null) focusMe.Focus();
	}
