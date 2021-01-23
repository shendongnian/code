    private void button1_Click_1(object sender, EventArgs e)
            {
                string _country = "";
                string _ServerName = "";
                LoginConfigurationSection LoginConfigurationSection = (LoginConfigurationSection)ConfigurationManager.GetSection("LoginConfiguration");
                if (LoginConfigurationSection != null)
                {
                    var UserCredentials = LoginConfigurationSection.Items
                                        .Cast<LoginElement>()
                                        .FirstOrDefault(_element => _element.UserName == "razi");
    
                    if (UserCredentials != null)
                        _country = UserCredentials.Country;
    
    
    
                    DBConfigurationSection section = (DBConfigurationSection)ConfigurationManager.GetSection("DBConfiguration");
                    if (section != null)
                    {
                        var DbConnection = section.Items
                                            .Cast<ItemsElement>()
                                            .FirstOrDefault(_element => _element.CountryCode.ToUpper() == _country.ToUpper());
    
                        if (DbConnection != null)
                            _ServerName = DbConnection.ServerName;
                    }
                }
            }
