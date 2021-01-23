            for (int i = 1; i <= rowCount; i++)
            {
                for (int j = 1; j <= xlRange.Rows[i].Columns.Count; j++)
                {
                    MessageBox.Show(xlRange.Cells[i, j].Value2.ToString());
                }
            }
