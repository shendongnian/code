    public static DataSet GetCart(string userName)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM [ShoppingCart] WHERE UserName = @UserName ", conn);
            cmd.CommandType = CommandType.Text;
        
            cmd.Parameters.AddWithValue("@UserName", userName);
        
            DataSet ds = new DataSet();
            SqlDataAdapter adapter1 = new SqlDataAdapter(cmd);
            adapter1.Fill(ds);
            conn.Close();
            return ds;
        }
