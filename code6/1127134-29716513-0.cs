    public static DataTable GetUserIdByName(string userName,string userType)
        {
            string conString = ConfigurationManager.ConnectionStrings["DefaultCSRConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_User WHERE Username=@Username AND UserType=@UserType", con);
                cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = userName;
                cmd.Parameters.Add("@UserType", SqlDbType.VarChar).Value = userType;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                return dt;
            }
        }
