    private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
            {
                
                if (((System.Windows.Forms.DataGridView)(sender)).Columns.Contains("Time"))
                {
                    int Column_index = ((System.Windows.Forms.DataGridView)(sender)).Columns["Time"].Index;
                    if ((e.ColumnIndex == Column_index) && (e.RowIndex != -1))
                    {
                        DateTime Grid_Time = (DateTime)e.Value;
                        if (Grid_Time.TimeOfDay < DateTime.Now.TimeOfDay )
                        {
                            e.CellStyle.BackColor = Color.Gray;
                        }
                        else
                        {
                            e.CellStyle.BackColor = Color.Green;
                        }
                    }
                }
            }
