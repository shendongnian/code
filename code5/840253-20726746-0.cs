    protected void Button2_Click(object sender, EventArgs e)
    {
    
        var myquery = string.Format("UPDATE DVD SET Stock = Stock - 1");
        conn.Open();
        using (OleDbCommand cmd = new OleDbCommand(myquery, conn))
            cmd.ExecuteNonQuery();
        conn.Close();
        conn.Dispose();
    }
