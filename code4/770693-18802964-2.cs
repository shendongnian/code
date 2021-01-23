       try
       {
            string cmdText = "select username, password from Login " + 
                             "where username=@uname and password=@pwd";
            using(SqlConnection con = new SqlConnection(.....))
            using(SqlCommand cmd = new SqlCommand(cmdText, con);
            {
                con.Open();
                cmd.Parameters.AddWithValue("@uname", textbox1.Text);
                cmd.Parameters.AddWithValue("@pwd", textbox2.Text);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                   ......
                }
            }
        {
        catch (Exception ex)
        {
             .....
        }
