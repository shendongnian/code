    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string Filter = textBox1.Text.Trim().Replace("'", "''");
            dataGridView1.DataSource = new BindingList<SWItem>(blist.Where(m => m.ServerName.Contains(Filter)).ToList<SWItem>());
        }
        catch (Exception ex)
        {
            new ToolTip().SetToolTip(textBox1, ex.Message);
        }
    }
