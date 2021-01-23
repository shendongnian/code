    string connStr = "datasource=localhost;port=3306;username=root;password=Achilles44";
    MySqlConnection conn = new MySqlConnection(connStr);
    try
    {
        string sql = "select *from test.edata ;";
        MySqlDataAdapter da = new MySqlDataAdapter(sql,conn);
        MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = sql;
        MySqlCommand insertCmd =cb.GetInsertCommand().Clone();
        insertCmd.CommandText = insertCmd.CommandText +";SELECT last_insert_id() AS id";
        insertCmd.UpdatedRowSource = UpdateRowSource.FirstReturnedRecord;
        da.InsertCommand = insertCmd;
        cb.DataAdapter = null;
        DataTable dt = new DataTable();
        da.Fill(dt);
        DataRow row = dt.NewRow();
        row["Familienname"] = " Schischka";
        row["Eid"] = 7;
        row["Vorname"] = "Hannes";
        row["age"] = "20";
        dt.Rows.Add(row);
        da.Update(dt);
        conn.Close();
    }
    catch(Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
