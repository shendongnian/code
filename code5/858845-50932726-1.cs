    {         
         OleDbConnection conn = new OleDbConnection("");
         OleDbCommand cmd = new OleDbCommand("select * from table_name", conn);
            
            {
                conn.Open();
                OleDbDataReader reader = cmd.ExecuteReader();
                {
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);
                    dataGridView1.DataSource = dataTable;
                }
                conn.Close();
            }
    }
