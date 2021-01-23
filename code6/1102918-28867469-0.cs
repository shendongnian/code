    public static class DataGridViewExtensions
        {
            public static void DeleteSelectedRows(this DataGridView dgv)
            {
                foreach (DataGridViewRow row in dgv.SelectedRows)
                    dgv.Rows.Remove(row);
            }
        }
