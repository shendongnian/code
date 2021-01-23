        [System.Web.Services.WebMethod(), System.Web.Script.Services.ScriptMethod()]
        public static List<string> GetAccountNumbers(string prefixText, int count)
        {
        	string CurUser = HttpContext.Current.User.Identity.Name.ToString();
        	using (SqlConnection conn = new SqlConnection())
        	{
        		conn.ConnectionString = ConfigurationManager.ConnectionStrings["CustDBConn"].ConnectionString;
        		using (SqlCommand cmd = new SqlCommand("SP_PCard_Get_AutoCompleteAccountNumbers", conn))
        		{
        			cmd.CommandType = CommandType.StoredProcedure;
        			cmd.Parameters.AddWithValue("@RecCount", count);
        			cmd.Parameters.AddWithValue("@SearchString", prefixText);
        			cmd.Parameters.AddWithValue("@UserName", CurUser);
        			cmd.Connection = conn;
        			conn.Open();
        			List<string> AccountNumbers = new List<string>();
        			using (SqlDataReader sdr = cmd.ExecuteReader())
        			{
        				while (sdr.Read())
        				{
        					AccountNumbers.Add(sdr["ACTNUMST"].ToString());
        				}
        			}
        			conn.Close();
        			return AccountNumbers;
        		}
        	}
        }
