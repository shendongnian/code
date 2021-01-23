    private bool EditFieldsAreValid()
    {
        if (string.IsNullOrWhiteSpace(txtEditName.Text) || string.IsNullOrWhiteSpace(txtEditAddress.Text))
            return false;
    
        return true;
    }
    
    private string CreateSql(string value)
    {
        return @"INSERT INTO [BRANCH] (bname,baddress,bcity,bstate,bpostcode,bphone,bfax,bemail,clientID)
             VALUES (@bname,@baddress,@bcity,@bstate,@bpostcode,@bphone,@bfax,@bemail,(SELECT clientID FROM [CLIENT] WHERE cname='" + value + "'))";
    }
    
        if (!EditFieldsAreValid())
        {
            lblBError.Enabled = true;
            lblBError.Visible = true;
            lblBError.Text = "Please provide the required field.";
            return;
        }
        if (string.IsNullOrWhiteSpace(txtControl.Text))
        {
            if (DropDownClient.Enabled && DropDownClient.SelectedItem.Value == "select")
            {
                lblBError.Enabled = true;
                lblBError.Visible = true;
                lblBError.Text = "Please select Client.";
            }
            else
            {
                if (string.IsNullOrWhiteSpace(lblClientName.Text))
                {
                    sql = CreateSql(lblClientName.Text);
                }
                else
                {
                    sql = CreateSql(DropDownClient.SelectedItem.Value);
                }
            }
        }
        else
        {
            sql = CreateSql(txtControl.Text.Trim());
        }
