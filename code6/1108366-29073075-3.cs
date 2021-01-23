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
    
            c.Items.Add(string.Format("x{0}:y{1} {2}", e.RowIndex, e.ColumnIndex, 0));
            c.Items.Add(string.Format("x{0}:y{1} {2}", e.RowIndex, e.ColumnIndex, 1));
            c.Items.Add(string.Format("x{0}:y{1} {2}", e.RowIndex, e.ColumnIndex, 2));
    
            // special handling
            if (e.RowIndex == e.ColumnIndex)
            {
                this.BeginInvoke(new Action(() =>
                {
                    _suppressCellBeginEdit = true;
                    this.Invoke(new Action(() => 
                        {
                            c.Value = s;
                            dgv[e.ColumnIndex, e.RowIndex] = c;
                            dgv[e.ColumnIndex, 0].Value = s1;
                        }));
                    _suppressCellBeginEdit = false;
                }));
            }
            else
            {
                c.Value = s;
                dgv[e.ColumnIndex, e.RowIndex] = c;
                dgv[e.ColumnIndex, 0].Value = s1;
            }
        }
    }
