     if(dt.Rows.Count > 0)
    {
    	UserId_Label.Text = "Someone already has that username, try another?";
    }
    elseif(!Page.IsValid)
    {
    	// Do what needs to be done when not valid
    	UserId_Label.Text = "Invalid username input";
    }
    else
    {
    	UserId_Label.Text = "Wow , its a unique username! please fill in the remaining fields of the form";
    }
     
