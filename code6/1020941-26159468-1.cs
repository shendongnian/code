    for (i = 0; i <= dataGridView1.RowCount - 2; i++)
                {
                    for (j = 0; j <= dataGridView1.ColumnCount - 1; j++)
                    {
                        Range range = (Range)xlWorkSheet.Cells[i + 1, j + 1];
                        xlWorkSheet.Cells[i + 1, j + 1] = dataGridView1[j, i].Value.ToString();
                        range.Interior.Color = System.Drawing.ColorTranslator.ToOle(dataGridView1.Rows[i].DefaultCellStyle.BackColor );
                        
                    }
                }
