    DataGridViewComboBoxCell cell = (DataGridViewComboBoxCell)dataGridVirtuals[e.ColumnIndex, e.RowIndex];
                if (cell.DataSource != null)
                {
                    List<string> values = (List<string>)cell.DataSource;
                    if (values.Count > 0)
                    {
                        e.Value = values[0];
                        e.FormattingApplied = true;
                    }
                }
