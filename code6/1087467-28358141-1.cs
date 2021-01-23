    // start with the last row, and work towards the first
    for (int n = dataGridView2.Rows.Count - 1; n >= 0; n--)
    {
        if (dataGridView2.Rows[n].Cells[2].Value != null)
        {
            if (dataGridView2.Rows[n].Cells[2].Value.Equals(dataGridView3.Rows[m].Cells[2].Value) &&
                dataGridView2.Rows[n].Cells[8].Value.Equals(dataGridView3.Rows[m].Cells[8].Value))
            {
                dataGridView2.Rows.RemoveAt(n);
                //break;
            }
        }
    }
