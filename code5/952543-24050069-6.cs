    if (oldValues) // Check if old values are stored
    {
        if (oldName != "") // check if its not an empty string
        {
            txtName.Text = oldName;
        }
        else // if it is a empty string then Clear the text box
            txtName.Clear();
        if (oldAddress != "")
        {
             txtAddress.Text = oldAddress;
        }
        else
            txtAddress.Clear();
        if (oldPhone != "")
        {
            txtPhone.Text = oldPhone;
        }
        else
            txtPhone.Clear();
        oldValues = false; // change the oldValues flag to false so that old values can be stored again...
    }    
