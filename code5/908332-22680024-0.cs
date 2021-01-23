    tx OracleTransaction;
    
    string myCommand ="Insert into....";
    Conn.Open();
    tx = Conn.BeginTransaction();
    OracleCommand cmd = new OracleCommand(myCommand, Conn);
    cmd.ExecuteScalar();
    
    private void Commit_button_Click(object sender, EventArgs e)
    {
        tx.Commit();
    }
    
    private void Rollback_button_Click(object sender, EventArgs e)
    {
        tx.Rollback();
    }
