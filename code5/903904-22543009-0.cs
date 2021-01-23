    TextBox b = sender as TextBox;
    if (b != null)
    {
       //Do stuff with it as a TextBox
    }
    else
    {
        ComboBox c = sender as ComboBox;
    
        //You should still perform the check here as a matter of good practice.
        if (c != null)
        {
            //Do stuff with it as a ComboBox
        }
    }
