        using System.Configuration;
        using System.Data
        
        SqlConnection _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStringDb"].ToString());
        
                   try
                    {
                      if(_connection.State==ConnectionState.Closed)
                        _connection.Open();
                    }
                    catch { }
