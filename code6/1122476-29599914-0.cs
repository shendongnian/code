    var hssfwb;
    using (var file = new FileStream(@"your_file.xls", FileMode.Open, FileAccess.Read))
    {
        hssfwb = new HSSFWorkbook(file);
        file.Close();
    }
    var sheet = hssfwb.GetSheetAt(0);
    for (int i = sheet.FirstRowNum; i <= sheet.LastRowNum; i++)
    {
        var row = sheet.GetRow(i);
        if (row != null)
        {
            foreach (ICell cell in row.Cells.Where(c => c.CellType == CellType.String))
                cell.SetCellValue(cell.StringCellValue.ToUpper());
        }
    }
