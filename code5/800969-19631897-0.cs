    for (int i = 0; i < dataGridView2.Rows.Count; i++)
    {
        if (dataGridView2.Rows[i].Cells[0].Value != null)
            label3.Text = dataGridView2.Rows[i].Cells[0].Value.ToString();
         else 
            label3.Text = "";
    }
