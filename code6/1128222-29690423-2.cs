    cmd2.Parameters.AddWithValue("@date1", dateTimePicker1.Value.Date);
    cmd2.Parameters.AddWithValue("@date2", dateTimePicker2.Value.Date);
    
    cmd2.ExecuteNonQuery();
    DataTable dt=new DataTable();
    OleDbDataAdapter da = new OleDbDataAdapter(cmd2);
    
    da.Fill(dt);
    dataGridView1.DataSource = dt;
    con.Close();    
