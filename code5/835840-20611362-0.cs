           private void dataGridView1_SelectionChanged(object sender, EventArgs e)
            {
                int selectedIndex=dataGridView1.SelectedRows[0].Index;
                CopyColumns();          
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    dataGridView2.Rows[0].Cells[i].Value = dataGridView1.Rows[selectedIndex].Cells[i].Value;
            }
    
            void CopyColumns()
            {
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    dataGridView2.Columns.Add(i.ToString(),dataGridView1.Columns[i].HeaderText);
            }
