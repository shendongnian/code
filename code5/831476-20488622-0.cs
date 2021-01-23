    using(var reader = cmd.ExecuteReader())
    {
        if(reader.Read())
        {
            txtGn.Text = reader["Groupno"].ToString();
            txtgname.Text=reader["Groupname"].ToString();
            txtsl.Text=reader["Slno"].ToString();
            txtsn.Text = reader["Subname"].ToString();
        }
        else
        {
            lblResults.Text = "Author not found";
        }
    }
