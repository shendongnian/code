    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        int orderId;
        if (!int.TryParse(textBox1.Text, out orderId))
            return;  // not a valid number
    
        DataView DV = new DataView(dataTable);
        DV.RowFilter = string.Format("OrderNo LIKE '%{0}%'", orderId);
        dataGridView1.DataSource = DV;
    }
