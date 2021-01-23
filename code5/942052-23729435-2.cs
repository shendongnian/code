     public DataTable ValidateUser(string username,string password)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd; SqlDataReader dr;
            SqlConnection con = new SqlConnection(yourConnectionString);
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "Select * from tblUsers where U_Name=@U_Name and U_Pass=@U_Pass";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@U_Name", username);
                cmd.Parameters.AddWithValue("@U_Pass", password);
                cmd.Connection = con;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                dr = cmd.ExecuteReader();
                dt.Load(dr);
            }
            catch (Exception ex)
            {
                dt = null;
               
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close(); con.Dispose();
                }
            }
            return dt;
        }
