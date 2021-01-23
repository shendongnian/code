    string connectionString = ""; //Set your MySQL connection string here.
    string query =""; // set query to fetch data "Select * from  tabelname"; 
    using(MySqlConnection conn = new MySqlConnection(connStr))
    {
        using(MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
        {
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            DataGridView1.DataSource= ds.Tables[0];
        }
    }
