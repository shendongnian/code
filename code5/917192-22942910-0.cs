    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string Filter = textBox1.Text.Trim().Replace("'", "''");
            IEnumerable<SWItem> sel = blist.Where(m => m.ServerName.Contains(Filter));
            BindingList<SWItem> blist2 = new BindingList<SWItem>();
            foreach (var item in sel.ToList<SWItem>())
            {
                blist2.Add(item);
            }
            dataGridView1.DataSource = blist2;
        }
        catch (Exception ex)
        {
            new ToolTip().SetToolTip(textBox1, ex.Message);
        }
    }
