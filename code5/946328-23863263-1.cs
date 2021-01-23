    if ((e.ColumnIndex == 4) && ((DataGridViewCell)dataGrid[e.ColumnIndex, e.RowIndex]).GetType() == typeof(DataGridViewComboBoxCell))  //check for ur comboboxcell index
            {
                DataGridViewComboBoxCell cell = (DataGridViewComboBoxCell)dataGrid[e.ColumnIndex, e.RowIndex];
                if (cell.DataSource != null)
                {
                    List<string> values = (List<string>)cell.DataSource;
                    if (values.Count > 0)
                    {
                        e.Value = values[0];
                        e.FormattingApplied = true;
                    }
                }
            }
