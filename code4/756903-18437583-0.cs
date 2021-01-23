    try
    {
        dataGridView.ScrollBars = ScrollBars.Both;
        dConn.Open();
        dAdapter4.Fill(ds4,"activities");
        dConn.Close();    
        dataGridView.DataSource = ds4.Tables[0].DefaultView;
    }
