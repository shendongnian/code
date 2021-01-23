    DataTable dt = new DataTable();
    using (var con = new SqlConnection("Data Source=local;Initial Catalog=Test;Integrated Security=True"))
    {
        using (var command = new SqlCommand("SELECT col1,col2" +
        {
            con.Open();
            using (SqlDataReader dr = command.ExecuteReader())
            {
                dt.Load(dr);
            }
        }
    }
