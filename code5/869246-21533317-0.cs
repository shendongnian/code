    using (var Sqlcmd = new SqlCommand("SELECT Name, Address from Student " + 
                                       "where Name LIKE @Name", conn))
    {
        cmd.Parameters.AddWithValue("@Name", "%" + txtSearch.Text "%");  
        using(SqlDataReader dReader = cmd.ExecuteReader())
        {
            String s = "";
            while (dReader.Read())
            {
                s+= dReader["Name"].ToString();
            }
            txtSearch.Text = s;
        }
     }
