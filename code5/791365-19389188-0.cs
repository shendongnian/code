    foreach (DataGridViewRow row in dataGridViewAddedBooks.Rows)
                    {
                        DataGridViewCheckBoxCell checkcell = (DataGridViewCheckBoxCell)row.Cells[0];
                        if (checkcell.Value == check.FalseValue)
                        {
                            dataGridViewAddedBooks.Rows.Remove(row);
                        }
                    }
