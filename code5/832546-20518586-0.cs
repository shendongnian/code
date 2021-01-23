     private void driverNo_TextChanged(object sender, EventArgs e)
     {
        BindingSource bs = new BindingSource();
        bs.DataSource = dataGridView1.DataSource;
        bs.Filter = "DriverNo like %" + driverNo.Text + "%";
        dataGridView1.DataSource = bs;
     }
