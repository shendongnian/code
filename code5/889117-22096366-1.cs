        myConnection.Open();
        SqlCommand objcmd = new SqlCommand("SELECT * FROM Customer", myConnection);
        DataTable dt = new DataTable(); using
        (SqlDataReader sqlDataReader = objcmd.ExecuteReader())
        {
            dt.Load(sqlDataReader);
            sqlDataReader.Close();
        }
        DataGridView dataGridView1 = new DataGridView();
        dataGridView1.DataSource = dt;
