    for (i = 0; i <= dgv.RowCount - 2; i++)
                {
                    for (j = 0; j <= dgv.ColumnCount - 1; j++)
                    {
                        Range range = (Range)xlWorkSheet.Cells[i + 1, j + 1];
                        xlWorkSheet.Cells[i + 1, j + 1] = dgv[j, i].Value.ToString();
                        range.Interior.Color = System.Drawing.ColorTranslator.ToOle(dgv.Rows[i + 1].DefaultCellStyle.BackColor );
                        
                    }
                }
