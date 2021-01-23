     private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             var _dataGrid = (DataGridView)sender;
            //Give your checkbox column Index
             int chkBoxColumnIndex = 0;
             if (e.ColumnIndex==chkBoxColumnIndex  && e.RowIndex >= 0)
             {
                 bool isChecked = _dataGrid[chkBoxColumnIndex, e.RowIndex].Value == null ? false : (bool)_dataGrid[chkBoxColumnIndex, e.RowIndex].Value;
                 dataGridView1.Columns[3].ReadOnly = isChecked;   
             }
        }
