    if (!oldValues)
    {
        if (txtName.Text != "")
        {
            oldName = txtName.Text;
        }
        if (txtAddress.Text != "")
        {
            oldAddress = txtAddress.Text;
        }
        if (txtPhone.Text != "")
        {
            oldPhone = txtPhone.Text;
        }
        oldValues = true;
        txtName.Clear();
        txtAddress.Clear();
        txtPhone.Clear();
    }
