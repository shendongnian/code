    else 
    {
        if(Page.IsValid)
        {
            UserId_Label.Text = "Wow , its a unique username! please fill in the remaining fields of the form";
        }
        else
        {
            // Do something here, because validation failed
        }
    }
