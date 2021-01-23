    private void FastDtToExcel(System.Data.DataTable dt, Worksheet sheet, int firstRow, int firstCol, int lastRow, int lastCol)
        {
            Range top = sheet.Cells[firstRow, firstCol];
            Range bottom = sheet.Cells[lastRow, lastCol];
            Range all = (Range)sheet.get_Range(top, bottom);
            string[,] arrayDT = new string[dt.Rows.Count, dt.Columns.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
                for (int j = 0; j < dt.Columns.Count; j++)
                    arrayDT[i, j] = dt.Rows[i][j].ToString();
            all.Value2 = arrayDT;
        }
