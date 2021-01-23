    using (SqlConnection con = new SqlConnection("Data Source=BETSY\\SQLEXPRESS;Initial Catalog=Sample;Integrated Security=True"))
    {
        con.Open();
        using (SqlCommand com = con.CreateCommand())
        {
            // sql setup stuff here
            using (SqlDataReader reader = com.ExecuteReader())
            {
                // read data here
            }
        }
    }
