    private void driverNo_TextChanged(object sender, EventArgs e)
    {
        // if driverNo text is empty then return all rows
        if (string.IsNullOrEmpty(driverNo.Text))
        {
            var bindingSource = (BindingSource)dataGridView1.DataSource.
            var table = (DataTable)bindingSource.DataSource;
            table.DefaultView.RowFilter = string.Empty;
            return;
        }
        // if driverNo is a numerical value then view result
        int temp;
        if (int.TryParse(driverNo.Text, out temp))
        {
            var bindingSource = (BindingSource)dataGridView1.DataSource.
            var table = (DataTable)bindingSource.DataSource;
            table.DefaultView.RowFilter = "DriverNo = " + driverNo.Text;
        }
        else
            MessageBox.Show("Invalid driver number.");
            driverNo.Text = "";
    }
