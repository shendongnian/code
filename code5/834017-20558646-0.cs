    private void searchBtn_Click(object sender, EventArgs e)
    {
        var list = new List<string>();
        using (var conn = new SqlConnection())
        {
            conn.ConnectionString = 
                "Data Source=.\SQLEXPRESS;Initial Catalog=master;Integrated Security=True";
            conn.Open();
            using (var cmd = new SqlCommand("SELECT cName FROM ComDet", conn))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(Convert.ToString(reader["cName"]));
                    }
                }
            }
       }
       ListU.DataSource = new BindingSource(list, null);
       ListU.DropDownStyle = ComboBoxStyle.DropDownList;
       ListU.Enabled = true;
    }
