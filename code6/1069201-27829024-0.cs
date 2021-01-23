    private static string GetCellReference(string filename, string sheetName, int rowIndex, string textToFind)
    {
        using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Open(filename, false))
        {
            WorkbookPart workbookPart = spreadsheetDocument.WorkbookPart;
            //get the correct sheet
            Sheet sheet = workbookPart.Workbook.Descendants<Sheet>().Where(s => s.Name == sheetName).First();
            if (sheet != null)
            {
                WorksheetPart worksheetPart = workbookPart.GetPartById(sheet.Id) as WorksheetPart;
                SharedStringTablePart stringTable = workbookPart.GetPartsOfType<SharedStringTablePart>().FirstOrDefault();
                SheetData sheetData = worksheetPart.Worksheet.Elements<SheetData>().First();
                Row row = sheetData.Elements<Row>().Where(r => r.RowIndex == rowIndex).First();
                if (row != null)
                {
                    foreach (Cell c in row.Elements<Cell>())
                    {
                        string cellText;
                        if (c.DataType == CellValues.SharedString)
                        {
                            //the value will be a number which is an index into the shared strings table
                            int index = int.Parse(c.CellValue.InnerText);
                            cellText = stringTable.SharedStringTable.ElementAt(index).InnerText;
                        }
                        else
                        {
                            //just take the value from the cell (note this won't work for dates and other types)
                            cellText = c.CellValue.InnerText;
                        }
                        if (cellText == textToFind)
                        {
                            return c.CellReference;
                        }
                    }
                }
            }
        }
        return null;
    }
