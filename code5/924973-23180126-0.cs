    if (e.ColumnIndex == 1)
                {
                    for (int k = 2; k <= 13; k++)
                    {
                        DataGridViewCell cell = dataGridView1.Rows[e.RowIndex].Cells[k];
                        DataGridViewCheckBoxCell checkCell = cell as DataGridViewCheckBoxCell;
                        checkCell.Value = dataGridView1.Rows[1].Cells[1].Value;
                    }
                }
