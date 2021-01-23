     public string connectionString = ConfigurationManager.ConnectionStrings["ConnectionName"].ConnectionString;
        
        public int get_details(string team1_name, string team2_name)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string sql = "insert into Table(team1_name,team2_name) values(@team1_name,@team2_name)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@team1_name", team1_name);
            cmd.Parameters.AddWithValue("@team2_name", team2_name);
            try
            {
                cmd.Connection = con;
                con.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
