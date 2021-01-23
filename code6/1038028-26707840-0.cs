     void dgrTonKho_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
            {
                if (e.ColumnIndex == 0 && e.RowIndex != this.dataGridView1.NewRowIndex)
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("0.00##");
                }
            }
 
