        private void btn_unselAll_Click(object sender, EventArgs e)
            {
                dictionaryDataGrid.ClearSelection();
    
                foreach (DataGridViewRow row in dictionaryDataGrid.Rows)
                {
                    ((DataGridViewCheckBoxCell)(row.Cells["ColSel"]).Value = false;
                }
        }
