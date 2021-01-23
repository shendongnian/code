    int numberOfColumns = sheet.GetRow(rowOffSet).PhysicalNumberOfCells;
    for (int i = 1; i <= numberOfColumns; i++)
    {
        sheet.AutoSizeColumn(i);
        GC.Collect(); // Add this line
    }
