            int row_index = e.RowIndex;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (row_index != i)
                {
                    dataGridView1.Rows[i].Cells["Column1"].Value = false;
                }
            }
