    void dataGridView1_CellFormatting(object sender,DataGridViewCellFormattingEventArgs e)
                {
                    if (e.ColumnIndex == 1 && e.RowIndex != this.dataGridView1.NewRowIndex)
                    {
                        e.Value = Decrypt(e.Value.ToString());
                    }
                }
