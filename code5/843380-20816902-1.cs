            for (int i = 0; i <= rowCount-1; i++)
            {
                for (int j = 0; j <= xlRange.Rows[0].Columns.Count-1; j++)
                {
                    MessageBox.Show(xlRange.Cells[i, j].Value2.ToString());
                }
            }
