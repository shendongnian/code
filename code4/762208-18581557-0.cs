    string query = "SELECT * FROM yourTableName";
    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connString);
    MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter);
    DataTable dt = new DataTable();
    adapter.Fill(dt);
    BindingSource bs = new BindingSource();
    bs.DataSource = dt;
    dgview.DataSource = bs;
