    class MyCustomDGV : DataGridView
    {
        private int currentCol = 0;
        private int currentRow = 0;
        // Store the current cell position.
        protected override void OnCellEnter(DataGridViewCellEventArgs e)
        {
            currentCol = e.ColumnIndex;
            currentRow = e.RowIndex;
            base.OnCellEnter(e);
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            // Extract the key code from the key value. 
            Keys key = (keyData & Keys.KeyCode);
            // Handle the ENTER key as if it were a RIGHT ARROW key.  
            if (key == Keys.Enter)
            {
                if (currentCol >= this.ColumnCount - 2)
                {
                    return this.ProcessEnterKey(keyData);
                }
                else
                {
                    return this.ProcessRightKey(keyData);
                }
                
            }
            return base.ProcessDialogKey(keyData);
        }
        protected override bool ProcessDataGridViewKey(KeyEventArgs e)
        {
            // Handle the ENTER key as if it were a RIGHT ARROW key.  
            if (e.KeyCode == Keys.Enter)
            {
                if (currentCol >= this.ColumnCount - 2)
                {
                    return this.ProcessEnterKey(e.KeyData);
                }
                else
                {
                    return this.ProcessRightKey(e.KeyData);
                }
            }
            return base.ProcessDataGridViewKey(e);
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (currentCol >= this.ColumnCount - 2)
                {
                    e.SuppressKeyPress = true;
                    e.Handled = true;
                    this.ProcessEnterKey(e.KeyData);
                    return;
                }
                else
                {
                    
                }
            }
            base.OnKeyDown(e);
        }
    }
