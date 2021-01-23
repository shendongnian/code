    using System.Windows.Forms;
    public static class DataGridViewExtensions
    {
        public static void TrimByCellValue(this DataGridView grid, string deleteme)
        {
            System.Diagnostics.Trace.WriteLine("DataGridViewExtensions->Trim()");
            foreach (DataGridViewRow _row in grid.Rows)
            {
                foreach (DataGridViewCell _cell in _row.Cells)
                {
                    if ((_cell.Value != null) && (!string.IsNullOrEmpty(_cell.Value.ToString())))
                    {
                        if ( _cell.Value.ToString().CompareTo(deleteme) == 0 )
                                grid.Rows.Remove(_row);
                    }
                }
            }
        }
    }
