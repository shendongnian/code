    // open the document read-only
    SpreadSheetDocument document = SpreadsheetDocument.Open(filePath, false);
    SharedStringTable sharedStringTable = document.WorkbookPart.SharedStringTablePart.SharedStringTable;
    string cellValue = null;
    foreach (WorksheetPart worksheetPart in document.WorkbookPart.WorksheetParts)
    {
        foreach (SheetData sheetData in worksheetPart.Worksheet.Elements<SheetData>())
        {
            if (sheetData.HasChildren)
            {
                foreach (Row row in sheetData.Elements<Row>())
                {
                    foreach (Cell cell in row.Elements<Cell>())
                    {
                        cellValue = cell.InnerText;
                        if (cell.DataType == CellValues.SharedString)
                        {
                            Console.WriteLine("cell val: " + sharedStringTable.ElementAt(Int32.Parse(cellValue)).InnerText);
                        }
                        else
                        {
                            Console.WriteLine("cell val: " + cellValue);
                        }
                    }
                }
            }
        }
    }
    document.Close();
