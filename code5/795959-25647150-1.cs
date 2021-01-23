        private void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
                if (e.Exception.Message == "DataGridViewComboBoxCell value is not valid.")
                {
                    object value = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    if (!((DataGridViewComboBoxColumn)dataGridView.Columns[e.ColumnIndex]).Items.Contains(value))
                    {
                        ((DataGridViewComboBoxColumn)dataGridView.Columns[e.ColumnIndex]).Items.Add(value);
                    }
                }
                throw e.Exception;
            }
            catch (Exception ex)
            {
                bool rethrow = ExceptionPolicy.HandleException(ex, "UI Policy");
                if (rethrow)
                {
                    throw;
                }
                MessageBox.Show(string.Format(@"Failed to bind ComboBox. "
                    + "Please contact support with this message:"
                    + "\n\n" + ex.Message));
            }
        }
