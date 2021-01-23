    using System.Web.Configuration;
    
    SqlConnection _connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnStringDb"].ToString());
    
               try
                {
                    _connection.Open();
                }
                catch { }
