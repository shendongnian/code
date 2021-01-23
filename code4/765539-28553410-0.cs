    public static void Fill(DataGridView dgv2)
       {
            try
            {
                dgv = dgv2;
                foreach (DataGridViewColumn GridCol in dgv.Columns)
                {
                    for (int j = 0; j < GridCol.DataGridView.ColumnCount; j++)
                    {
                        GridCol.DataGridView.Columns[j].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        GridCol.DataGridView.Columns[j].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        GridCol.DataGridView.Columns[j].FillWeight = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
