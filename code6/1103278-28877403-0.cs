    private void Sum()
    {
        Double sum = 0;
        for(int i = 0; i < dataGridView1.Rows.Count; i++)
        {
            sum += Double.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
        }
        lblTotal.Text = sum.ToString();
    }
