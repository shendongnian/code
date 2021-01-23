    string connectionString = "SERVER=" + server + ";" + "DATABASE=" +
    database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
    MySqlConnection conn = new MySqlConnection(connectionString);
    MySqlDataAdapter adptr = new MySqlDataAdapter("Select * FROM " + tableName, conn);
    DataTable tabloSql = new DataTable();
    adptr.Fill(tabloSql);
    dataGridView1.DataSource = tabloSql;
           
