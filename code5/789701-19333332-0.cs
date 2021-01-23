       private void button1_Click(object sender, EventArgs e)
       {
            string cmdText = "SELECT * FROM BillingSystem " + 
                             "WHERE DateOfTransaction BETWEEN ? AND ?";
            DateTime dt = this.dateTimePicker1.Value.Date;
            DateTime dt2 = this.dateTimePicker1.Value.Date.AddMinutes(1440);
            command.CommandText = cmdText;
            command.Parameters.AddWithValue("@p1",dt1);
            command.Parameters.AddWithValue("@p2",dt2);
            OleDbDataAdapter adapter = new OleDbDataAdapter(command, connectionBilling);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            connectionBilling.Close();
        }
