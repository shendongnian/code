    while (reader.Read())
    {
        DataGridViewRow rowadd = (DataGridViewRow)customersDataGridView.Rows[0].Clone();
    
        if (!string.IsNullOrWhiteSpace(reader["Customer_ID"].ToString()))
        {
             rowadd.Cells[0].Value = reader["Customer_ID"].ToString();
             //Others Stuff
             //...
             this.customersDataGridView.AllowUserToAddRows = false;
             customersDataGridView.Rows.Add(rowadd);
        }
    }
