     public partial class Admin : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                DataSet ds = new DataSet("ot_Users");
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString))
    			{
    				using (SqlCommand command = conn.CreateCommand())
    				{
					command.CommandText = "dbo.ot_User_GetByUserName";
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.AddWithValue("@UserName", Environment.UserName);
					conn.Open();
					SqlDataReader reader = command.ExecuteReader();
					ot_Users user = new ot_Users();
					while(reader.Read())
					{
						 user.CompanyId = reader["CompanyId"] != DBNull.Value ? (int)reader["CompanyId"] : 0 ;
						 user.UserId = reader["UserId"] != DBNull.Value ? (int)reader["UserId"] : 0 ;
						 user.FirstName = reader["FirstName"] != DBNull.Value ? reader["FirstName"].ToString() : string.Empty;
						 user.LastName = reader["LastName"] != DBNull.Value ? reader["LastName"].ToString() : string.Empty;
						 user.CompanyAdmin = reader["CompanyAdmin"] != DBNull.Value ? (bool)reader["CompanyAdmin"] : false ;
						 user.AccountStatus = reader["AccountStatus"] != DBNull.Value ? (int)reader["AccountStatus"] : 0 ;
						 user.UserName = reader["UserName"] != DBNull.Value ? reader["UserName"].ToString() : string.Empty;
					}
					if (user != null)
					{
						CompanyName.Text = user.FirstName.ToString();
					}
				}
			}
        }
    }
