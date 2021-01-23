    public List<AccountDetails> GetAccountDetails()
    {
    	using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["VPO"].ConnectionString))
    	{
    		string sql = "SELECT DISTINCT A.account_id, A.fname, A.lname, 
    					  FROM T_Test1 A WITH (NOLOCK) 
    					  JOIN T_Test2 AF WITH (NOLOCK) ON A.Account_id=AF.Account_id
    					  WHERE account_status = 'A' AND A.card IS NOT NULL
    						AND A.dateFrom >= '09-02-2013 00:00:00' 
    						AND A.dateFrom <= '09-30-2013 00:00:00' 
    						AND AF.code = 'INE'";
    
    		SqlCommand command = new SqlCommand(sql.ToString(), connection);
    		command.CommandTimeout = 3600;
    
    		connection.Open();
    		var accDetails = new List<AccountDetails>();
    		
    		using (var rdr = cmd.ExecuteReader())
                {
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            var accountDetails = new AccountDetails{
                                AccountId = rdr.GetInt32(0),
                                FName = rdr.GetString(1),
                                LName = rdr.GetString(2)
                            };
                        }
    					accDetails.Add(accountDetails);					
                    }
                }
    	}
    	
    	return accDetails;
    }
