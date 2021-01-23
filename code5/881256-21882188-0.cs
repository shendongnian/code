     class customDataGridView : DataGridView
            {
                protected override bool ProcessDialogKey(Keys keyData)
                {
                    if (keyData == Keys.Enter)
                    {
                        int col = this.CurrentCell.ColumnIndex;
                        int row = this.CurrentCell.RowIndex;
                        this.CurrentCell = this[col, row];
                        return true;
                    }
                    return base.ProcessDialogKey(keyData);
                }
    
                protected override void OnKeyDown(KeyEventArgs e)
                {
                    if (e.KeyData == Keys.Enter)
                    {
                        int col = this.CurrentCell.ColumnIndex;
                        int row = this.CurrentCell.RowIndex;
                        this.CurrentCell = this[col, row];
                        e.Handled = true;
                    }
                    base.OnKeyDown(e);
                }
            }
