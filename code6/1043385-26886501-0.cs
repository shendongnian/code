    protected string ManagerData(String sValue)
    {
        string UsrName = User.Identity.Name;
        string mName;
        string mNum;
        using (SqlConnection connection = new SqlConnection(Common.ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("select ManagerName,ManagerNumber from Managers where UserName=@UserName"))
            {
                SqlParameter para = new SqlParameter("UserName", UsrName);
                cmd.Parameters.Add(para);
                cmd.Connection = connection;
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    mName = reader.GetString(0);
                    mNum = reader.GetString(1);
                }
            }
        }
    	
    	if(sValue = "name")
    	 return mName;
    	else
    	 return mNum    
    }
    <h5>Your Manager is:<%:ManagerData("name") %> </h5>
    <h5>Your Managers Number is:<%:ManagerData("number") %> </h5> 
