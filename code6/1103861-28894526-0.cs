            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                if (!dr.IsNewRow)
                {
                    for (int c = 0; c <= dr.Cells.Count - 1; c++)
                    {
                        if (dr.Cells[c].Value == null)
                        {
                            dr.Cells[c].Value = "NULL TEXT";
                        }
                    }
                }
            }
