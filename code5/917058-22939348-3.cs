    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        //table = fill the table with proper values by accessing the database
        if (textBox1.Text != "")
        {
            DataView dv = table.DefaultView;
            dv.RowFilter = string.Format("Name = '{0}'", textBox1.Text);
            dataGridView1.DataSource = dv;
            dataGridView1.DataBind();
        }
        else if (textBox1.Text == "")
        {
            dataGridView1.DataSource = table;
            dataGridView1.DataBind();
        }
    }
