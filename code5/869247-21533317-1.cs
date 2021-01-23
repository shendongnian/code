    using (var Sqlcmd = new SqlCommand("SELECT Name, Address from Student " + 
                                       "where Name LIKE @Name", conn))
    {
        cmd.Parameters.AddWithValue("@Name", "%" + txtSearch.Text "%");  
        using(SqlDataReader dReader = cmd.ExecuteReader())
        {
            StringBuilder s = new StringBuilder(1024);
            while (dReader.Read())
            {
                s.Append(dReader["Name"].ToString());
            }
            txtSearch.Text = s.ToString();
        }
     }
