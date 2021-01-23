      private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.RowIndex >= 0)
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                    {
                        string text = (String)
                         dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                        if (text != null)
                            dataGridView1.DoDragDrop(text, DragDropEffects.Copy);
                    }
                }  
              
            }
        }
        private void textBox1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(System.String)))
            {
                textBox1.Text = (System.String)e.Data.GetData(typeof(System.String));
            }
        }
        private void textBox1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
