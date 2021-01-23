      foreach (DataGridViewRow row in form1.dataGridView1.SelectedRows)
            {
                bool isnotexist = true;
                foreach (DataGridViewRow rowgrid2 in dataGridView2.Rows)
                {
                    if (rowgrid2.Cells[0].Value.ToString() == row.Cells[0].Value.ToString())
                    {
                        isnotexist = false;
                        break;
                    }
                }
                if (isnotexist)
                {
                    int index = dataGridView2.Rows.Add(row.Clone() as DataGridViewRow);
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        dataGridView2.Rows[index].Cells[cell.ColumnIndex].Value = cell.Value;
                    }
                }
            }
