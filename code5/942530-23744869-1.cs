    string connstring = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
    using(SqlConnection conn = new SqlConnection(connstring))
    {
        string sql = "INSERT INTO PARTS VALUES(@name, @description, @quantity, @categoryList)"
        using(SqlCommand cmd = new SqlCommand(sql , conn))
        {
            cmd.Parameters.AddWithValue("@name", nameBox.Text);
            ... etc.
            cmd.ExecuteNonQuery();
        }
    }
