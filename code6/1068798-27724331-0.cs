    int rowIndex = 0;
            int cellIndex = 0;
            Color c = Color.Gray;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                var cells = row.Cells;
                if (cells.Count > 0)
                {
                    cellIndex = 0;
                    foreach (DataGridViewCell cell in cells)
                    {
                        dataGridView1.Rows[rowIndex].Cells[cellIndex].Style.BackColor = c;
                       
                        cellIndex++;
                    }
                    if (cells[0].Value != null)
                        if ((cells[0].Value as string).Contains("==="))
                        {
                            c = ((c == Color.Gray) ? Color.Transparent : Color.Gray);
                        }
                }
                rowIndex++;
            }
            rowIndex = 0;
