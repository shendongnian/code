    public void _adapter_RowUpdated(dynamic sender, System.Data.OleDb.OleDbRowUpdatedEventArgs e)
    {
        HMUI.Classes.AccessIDHelper.SetPrimaryKey(this.Connection, e);
    }
    public static void SetPrimaryKey(OleDbConnection trans, OleDbRowUpdatedEventArgs e)
    {
        if (e.Status == System.Data.UpdateStatus.Continue && e.StatementType == System.Data.StatementType.Insert)
            {                
                if (pk != null)
                {
                    OleDbCommand cmdGetIdentity = new OleDbCommand("SELECT @@IDENTITY", trans); 
                    // Execute the post-update query to fetch new @@Identity
                    e.Row.Table.Columns[pk(0)] = Convert.ToInt32(cmdGetIdentity.ExecuteScalar());
                    e.Row.AcceptChanges();
                }
            }
        }
