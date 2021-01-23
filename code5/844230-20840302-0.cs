    String qu = "select * from invoice_master where  modify_date between ? and ?" + 
    using(OleDbConnection con = new OleDbConnection(connection))
    using(OleDbDataAdapter adapter = new OleDbDataAdapter(query, con))
    {
        DataTable dt = new DataTable();
        adapter.SelectCommand.Parameters.AddWithValue("@p1", dateTimePicker1.Value)
        adapter.SelectCommand.Parameters.AddWithValue("@p2", dateTimePicker2.Value)
        adapter.Fill(dt);
    }
