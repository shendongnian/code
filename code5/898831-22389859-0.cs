     private void dataGridView1_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            try
            {
                if (DBNull.Value.Equals(e.CellValue1) || DBNull.Value.Equals(e.CellValue2))
                {
                    if (DBNull.Value.Equals(e.CellValue1) || e.CellValue1.Equals(null))
                    {
                        e.SortResult = 1;
                    }
                    else if (DBNull.Value.Equals(e.CellValue2) || e.CellValue2.Equals(null))
                    {
                        e.SortResult = -1;
                    }
                }
                else
                {
                    e.SortResult = (e.CellValue1 as IComparable).CompareTo(e.CellValue2 as IComparable);
                }
    e.Handled = true
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
