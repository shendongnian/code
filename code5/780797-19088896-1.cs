    if (string.IsNullOrWhitespace(txtEditName.Text) || string.IsNullOrWhitespace(txtEditAddress.Text))
    {
        lblBError.Enabled = true;
        lblBError.Visible = true;
        lblBError.Text = "Please provide the required field.";
        return;
    }
    else
    {
        if (!string.IsNullOrWhitespace(txtControl.Text))
        {
            if (DropDownClient.Enabled && DropDownClient.SelectedItem.Value == "select")
            {
                lblBError.Enabled = true;
                lblBError.Visible = true;
                lblBError.Text = "Please select Client.";
                return;
            }
            else
            {
                if (!string.IsNullOrWhitespace(lblClientName.Text))
                {
                    sql = @"INSERT INTO [BRANCH] (bname,baddress,bcity,bstate,bpostcode,bphone,bfax,bemail,clientID)
                            VALUES (@bname,@baddress,@bcity,@bstate,@bpostcode,@bphone,@bfax,@bemail,(SELECT clientID FROM [CLIENT] WHERE cname='" + lblClientName.Text + "'))";
                }
                else
                {
                    sql = @"INSERT INTO [BRANCH] (bname,baddress,bcity,bstate,bpostcode,bphone,bfax,bemail,clientID)
                    VALUES (@bname,@baddress,@bcity,@bstate,@bpostcode,@bphone,@bfax,@bemail," + DropDownClient.SelectedItem.Value + ")";
                }
            }
            else
            {
                sql = @"INSERT INTO [BRANCH] (bname,baddress,bcity,bstate,bpostcode,bphone,bfax,bemail,clientID)
                VALUES (@bname,@baddress,@bcity,@bstate,@bpostcode,@bphone,@bfax,@bemail," + Convert.ToInt32(txtControl.Text.Trim()) + " )";
                    //  SqlCommand cmd = new SqlCommand(sql, connection);
            }
    	}
    }
