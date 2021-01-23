    private void button1_Click(object sender, EventArgs e)
    {
        int countColumn, intCell = -1, intRow = -1;
        countColumn = dataGridView1.Columns.Count;
        foreach (DataGridViewRow row in dataGridView1.Rows)
        {
            intRow++;
            foreach (DataGridViewCell c in row.Cells)
            {
                if (c.Value != null)
                {
                    if (c.Value.ToString() == "0.04")
                    {
                        intCell = +1;
                        dataGridView1.Rows[intRow].Cells[intCell].Value = "0";
                        if (intCell == countColumn)
                        {
                            intCell = -1;
                        }
                    }
                }
            }
        }
    }
