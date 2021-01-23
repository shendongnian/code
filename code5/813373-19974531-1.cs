    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                string val = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                textBox1.Text = val;
                this.Close();
            }
            public string _textBox1
            {
                get { return textBox1.Text.Trim(); }
            }
 
