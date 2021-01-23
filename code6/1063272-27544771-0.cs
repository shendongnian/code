    MySqlConnection conn = new MySqlConnection(connection);
    MySqlCommand command = start.CreateCommand();
    command.CommandText = "SELECT id, muayine_adi, sabit_qiymet FROM tibbi_xidmetler  WHERE id = '" + id.ToString() + "'";
    conn.Open();
    MySqlDataAdapter oxu = new MySqlDataAdapter(command);
    DataTable dt = new DataTable();
    oxu.Fill(dt);
    if(dataGridView2.DataSource != null) {
        DataTable pr = dataGridView2.DataSource as DataTable;
        pr.Merge(dt);
        dataGridView2.DataSource = pr;
    }
    else
        dataGridView2.DataSource = dt;
