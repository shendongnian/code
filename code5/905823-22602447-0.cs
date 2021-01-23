    protected void btnsearch_Click(object sender, EventArgs e)
     {       
    	var searchresult = SqlInjection(txtsearch.Text.ToString());
    	var dt = GetData(searchresult);
    	if(dt != null)
    	{
            	GridView2.DataSource= dt;
    		GridView2.DataBind();
    	}
     }
    
    private DataTable GetData(string searchvalue)
            {
                using (var dataset = new DataSet())
                {
                    dataset.Locale = CultureInfo.InvariantCulture;
                    using (var connection = new SqlConnection("Your connection string"))
                    {
                        using (var sqlCommand = new SqlCommand("write your store procedure name here", connection))
                        {
                            sqlCommand.Parameters.AddWithValue("parameter name from store procedure", searchvalue);
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            sqlCommand.CommandTimeout = 180;
                            using (var sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                            {
                                dataset.Reset();
                                sqlDataAdapter.Fill(dataset);
                                sqlCommand.Connection.Close();
                            }
                        }
                    }
    
                    return dataset.Tables[0];
                }
            }
    
    private static string SqlInjection(string stringValue)
            {
                if (null == stringValue)
                {
                    return null;
                }
        enter code here
                return stringValue
                            .RegexReplace("-{2,}", "-")                 // transforms multiple --- in - use to comment in sql scripts                        
                            .RegexReplace(@"(;|\s)(exec|execute|select|insert|update|delete|create|alter|drop|rename|truncate|backup|restore)\s", string.Empty, RegexOptions.IgnoreCase);
            }
