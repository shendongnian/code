    public void Generate()
    {
        HSSFWorkbook newWorkBook = new HSSFWorkbook();
        HSSFSheet newSheet = (HSSFSheet)newWorkBook.CreateSheet("Main");
        var headerRow = newSheet.CreateRow(0);
        var headerCell = headerRow.CreateCell(0);
        headerCell.SetCellValue("Something");
        using (FileStream fileOut = new FileStream(filePath, FileMode.Create))
        {
            newWorkBook.Write(fileOut);
        }
    }
