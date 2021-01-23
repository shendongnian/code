    private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex==0)
           {
            SqlDataAdapter ad = new SqlDataAdapter(@"SELECT id from Customer", connection);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            int value = int.Parse(e.FormattedValue.ToString());
            DataRow[] dr = dt.Select("id = " + value);
            if (!dr.Any())
            {
                  message.show("Foreign key problem");
             }
            else {
            Form2 second = new Form2();
            this.AddOwnedForm(second);
            second.Show();
             }
            }    
    
    }
