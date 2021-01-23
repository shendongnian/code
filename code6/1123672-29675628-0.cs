                for (int x = 1; x <= totalCols; x++)
            {
                var colName = excelWorksheet.Cells[1, x].Value.ToString().Replace(" ", String.Empty);
                if (!dt.Columns.Contains(colName))
                    dt.Columns.Add(colName);
            }
            Parallel.For(2, totalRows + 1, (i) =>
            {
                DataRow dr = null;
                for (int j = 1; j <= totalCols; j++)
                {
                    dr = dt.NewRow();
                    dr[j - 1] = excelWorksheet.Cells[i, j].Value != null
                        ? excelWorksheet.Cells[i, j].Value.ToString()
                        : null;
                    lock (lockObject)
                    {
                        dt.Rows.Add(dr);
                    }
                }
            });
