    string connection = "server = URL; uid = user; pwd = password; database = database;";
    using (MySqlConnection conn = new MySqlConnection(connection)) {
        
        conn.Open();
        string idLocRemv = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
        string removeVolCred = "DELETE FROM TableName WHERE ID = " + idLocRemv;
        using (MySqlCommand command = new MySqlCommand(removeVolCred, fbcConn)) {
            command.ExecuteNonQuery();
        }
        conn.Close();
    }
