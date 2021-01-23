    DataTable dt = new DataTable();
    using (SqlConnection con = povezava) {
        using (SqlCommand command = con.CreateCommand()) {
            command.CommandText = tb_koda.Text;
            con.Open();
            using (SqlDataAdapter adapter = new SqlDataAdapter(command)) 
                adapter.Fill(dt);
        }
    }
