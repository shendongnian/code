    private bool _suppressCellBeginEdit = false;
    private void dgv_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
    {
        var dgv = sender as DataGridView;
        if (_suppressCellBeginEdit)
            return;
                
        if (e.ColumnIndex == 2 && e.RowIndex >= 0)
        {
            string s = Convert.ToString(dgv[e.ColumnIndex, e.RowIndex].Value);
            string s1 = Convert.ToString(dgv[e.ColumnIndex, 0].Value);
            DataGridViewComboBoxCell c = new DataGridViewComboBoxCell();
    
            c.Items.Add(e.RowIndex.ToString() + " " + GetExcelColumnName(e.ColumnIndex));
            c.Items.Add(e.RowIndex.ToString() + " " + GetExcelColumnName(e.ColumnIndex + 1));
            c.Items.Add(e.RowIndex.ToString() + " " + GetExcelColumnName(e.ColumnIndex + 2));
    
            // special handling
            if (e.RowIndex == e.ColumnIndex)
            {
                this.BeginInvoke(new Action(() =>
                {
                    _suppressCellBeginEdit = true;
                    this.Invoke(new Action(() => dgv[e.ColumnIndex, e.RowIndex] = c));
                    _suppressCellBeginEdit = false;
                }));
            }
            else                    
                dgv[e.ColumnIndex, e.RowIndex] = c; // Heres the error When e.RowIndex == 2 and if e.RowIndex != 2 then no error
                        
            dgv[e.ColumnIndex, e.RowIndex].Value = s;
            dgv[e.ColumnIndex, 0].Value = s1;
        }
    }
