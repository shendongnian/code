    private void ReadIntoTable(ExcelWorksheet sheet)
    {
        DataTable dt = new DataTable(sheet.Name);
        int height = sheet.Dimension.Rows;
        int width = sheet.Dimension.Columns;
        for (int j = 1; j <= width; j++)
        {
            string colText = (sheet.Cells[1, j].Value ?? "").ToString();
            dt.Columns.Add(colText);
        }
        for (int i = 2; i <= height; i++)
        {
            dt.Rows.Add();
        }
        Parallel.For(1, height, (i) =>
        {
            var row = dt.Rows[i - 1];
            for (int j = 0; j < width; j++)
            {
                string str = (sheet.Cells[i + 1, j + 1].Value ?? "").ToString();
                row[j] = str;
            }
        });
        // convert to your special Excel data model
        // ...
    }
