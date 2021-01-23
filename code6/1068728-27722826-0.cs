    >    for (int i = 0; i < dataGridView1.SelectedRows.Count-1; i++)
    >             {
    >                for (int j = 0; j < dataGridView1.SelectedRows.rows[i].Cells.Count; j++)
    >                 {
    >                     if                     (dataGridView1.SelectedRows.rows[i].Cells[j].value.Equals(dataGridView1.SelectedRows.rows[i+1].Cells[j].value))
    >                     {
    >                         dataGridView1.SelectedRows.Rows[i].Cells[j].Style.BackColor = Color.Red;
    >                         dataGridView1.SelectedRows.Rows[i].Cells[j].Style.BackColor = Color.Red;
    >                     }
    >                 }
    >             }
