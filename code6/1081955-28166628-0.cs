     private void Form1_Load(object sender, EventArgs e)
        {
            DataGridViewComboBoxColumn cmb = (DataGridViewComboBoxColumn)dataGridView1.Columns[0];          
            cmb.Name = "cmb";
            cmb.MaxDropDownItems = 4;
            int no = 1001;
            for (int i = 0; i < 100; i++)
            {
                no++;
                cmb.Items.Add(no.ToString());
            }            
            dataGridView1.RefreshEdit();
            dataGridView1.Rows.Add();
           
        }
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(e.ColumnIndex==0)// ItemId
                {
                    dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[4];
                    dataGridView1.CurrentCell.Value = "1";
                    dataGridView1.BeginEdit(true);                    
                }
                else if (e.ColumnIndex == 4)// NoofQty
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex+1].Cells[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
