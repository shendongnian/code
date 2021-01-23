    MySqlConnection conn = new MySqlConnection(connectionString);
    MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM Test", conn);
    MySqlCommandBuilder cb = new MySqlCommandBuilder(da, true);
    DataTable dt = new DataTable();
    da.Fill(dt);
    //update datatable
    dt.Rows[0][0] = “my changed value”;
    DataTable changes = dt.GetChanges();
    //call update 
    Da.Update(changes);
    dt.AcceptChanges();
