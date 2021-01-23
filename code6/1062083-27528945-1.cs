    HSSFWorkbook hssfwb;
    using (FileStream file = new FileStream(@"c:\temp\testfile.xls", FileMode.Open, FileAccess.Read))
    {
        hssfwb = new HSSFWorkbook(file);
        file.Close();
    }
    ISheet sheet = hssfwb.GetSheetAt(0);
    IRow row = sheet.GetRow(0);
    sheet.CreateRow(row.LastCellNum);
    ICell cell = row.CreateCell(row.LastCellNum);
    cell.SetCellValue("test");
    for (int i = 0; i < row.LastCellNum; i++)
    {
        Console.WriteLine(row.GetCell(i));
    }
    using (FileStream file = new FileStream(@"c:\temp\testfile.xls", FileMode.Open, FileAccess.Write))
    {
        hssfwb.Write(file);
        file.Close();
    }
