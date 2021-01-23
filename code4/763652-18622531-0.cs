    using (OleDbConnection con = new OleDbConnection("CONNECTION STRING"))
    {
        con.Open();
        DataTable dtusers = new DataTable();
        using(OleDbCommand cmd = new OleDbCommand("Select Code,Description,Qnty,Rate from PurchaseTable'", con))
        {
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dtusers);
            dataGridView1.DataSource = dtusers;
        } 
        con.Close(); 
    } 
