    if (oldValues)
    {
        if (oldName != "")
        {
            txtName.Text = oldName;
        }
        else
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
        oldValues = false;
    }    
