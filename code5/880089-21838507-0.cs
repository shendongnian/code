    public string UserName {get; private set;}
    
    if (string.Compare(dbPassword, appPassword) == 0)
                    {
                        UserName = txtUser.Text;
                        //I need to pass username value to myForm...
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        //Show warning
                    }
