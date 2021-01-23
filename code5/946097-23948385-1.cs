    [WebMethod]
                [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
            public String GetAllResources()
                {
                    String conString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
                    List<Dictionary<string, object>> tableRows = new List<Dictionary<string, object>>();
                    Dictionary<string, object> row= new Dictionary<string,object>();
                    DataTable dt = new DataTable();
                    System.Web.Script.Serialization.JavaScriptSerializer serializer =
              new System.Web.Script.Serialization.JavaScriptSerializer();
    
                    try
                    {
                        using (MySqlConnection cnn = new MySqlConnection(conString))
                                        {                                        
                                            cnn.Open();
                                            String sql = String.Format("select resourceID, resourceName, resourceDesc, roomID from resources");
                                            MySqlCommand cmd = new MySqlCommand(sql, cnn);
                                            MySqlDataReader reader = cmd.ExecuteReader();
                                            dt.Load(reader);
    
                                            foreach (DataRow dr in dt.Rows)
                                            {
                                                row = new Dictionary<String, Object>();
                                                foreach (DataColumn col in dt.Columns)
                                                {
                                                    row.Add(col.ColumnName, dr[col]);
                                                }
                                                tableRows.Add(row);
                                            }
                                            return serializer.Serialize(tableRows);
                                        }
                    }
                    catch (Exception ex)
                    {
                        return ex.ToString();
                    }            
                }
