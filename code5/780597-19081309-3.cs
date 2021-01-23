    private void adapter_RowUpdated(object sender, System.Data.OleDb.OleDbRowUpdatedEventArgs e)
    {
        if (e.Status == UpdateStatus.Continue && e.StatementType == StatementType.Insert)
        {
            int id = 0;
            using (OleDbConnection con = new OleDbConnection( .... con string here ....))
            using (OleDbCommand cmd = new OleDbCommand("SELECT @@IDENTITY", con))
            {
                con.Open();
                id = (int)cmd.ExecuteScalar();
            }
            e.Row["ID"] = id;
        }
    }
   
 
