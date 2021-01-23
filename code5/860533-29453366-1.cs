    private void button1_Click(object sender, EventArgs e)
            {
    
    
     
                myAccesscon.ConnectionString = connectionString;
    
    
    
                dataGridView.DataSource = null;
                dataGridView.Update();
                dataGridView.Refresh();
               OleDbCommand cmd = new OleDbCommand(sql, myAccesscon);
                myAccesscon.Open();
                cmd.CommandType = CommandType.Text;
               OleDbDataAdapter da = new OleDbDataAdapter(cmd);
               DataTable bookings = new DataTable();
                da.Fill(bookings);
                dataGridView.DataSource = bookings;
                myAccesscon.Close();
    
               
            }
