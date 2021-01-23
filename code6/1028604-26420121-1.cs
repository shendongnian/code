    private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
            {
                if (dataGridView1.CurrentCell.ColumnIndex==0)
                {
                    
                    comboBox1.Visible = true;
                    comboBox1.Location = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Location;
                    comboBox1.Size = dataGridView1.CurrentCell.Size;
                   comboBox1_SelectedIndexChanged(null, null);
                    comboBox1.Focus();//focus on Combobox
                }
            }
`
