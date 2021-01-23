                           if (DropDownClient.SelectedItem.Value == "select")
                            {
                                lblBError.Enabled = true;
                                lblBError.Visible = true;
                                lblBError.Text = "Please select Client.";
    
                                return;
    
                            }
                            else
                            {
                                if (lblClientName.Text.Trim() != "")
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
