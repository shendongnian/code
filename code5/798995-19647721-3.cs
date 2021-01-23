        [System.Web.Services.WebMethod(), System.Web.Script.Services.ScriptMethod()]
        public static bool ValidateGLAccountAccess(string GLAccountNum)
        {
        	string RetValue = string.Empty;
        	string CurUser = HttpContext.Current.User.Identity.Name.ToString();
        	using (SqlConnection conn = new SqlConnection())
        	{
        		conn.ConnectionString = ConfigurationManager.ConnectionStrings["CustDBConn"].ConnectionString;
        		using (SqlCommand cmd = new SqlCommand("SP_PCard_Get_SelectedGLAcountNumber", conn))
        		{
        			cmd.CommandType = CommandType.StoredProcedure;
        			cmd.Parameters.AddWithValue("@SearchString", GLAccountNum);
        			cmd.Parameters.AddWithValue("@UserName", CurUser);
        			cmd.Connection = conn;
        			conn.Open();
        			RetValue = (string)cmd.ExecuteScalar();
        			conn.Close();
        		}
        	}
        	Boolean myVarBool = false;
        	if (RetValue == GLAccountNum)
        	{
        		myVarBool = true;
        	}
        	return myVarBool;
        }
