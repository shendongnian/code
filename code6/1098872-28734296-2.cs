    //open the file
    using (SpreadsheetDocument myDoc = SpreadsheetDocument.Open(path, true))
    {
         //Get workbookpart
         WorkbookPart workbookPart = myDoc.WorkbookPart;
    
         // Extract the workbook part
         var stringtable = workbookPart.GetPartsOfType<SharedStringTablePart>().FirstOrDefault();
    
        //then access to the worksheet part
        IEnumerable<WorksheetPart> worksheetPart = workbookPart.WorksheetParts;
    
        foreach (WorksheetPart WSP in worksheetPart)
        {
            //find sheet data
            IEnumerable<SheetData> sheetData = WSP.Worksheet.Elements<SheetData>();
    
           foreach (SheetData SD in sheetData)
           {
                foreach (Row row in SD.Elements<Row>())
                {
                    // For each cell we need to identify type
                    foreach (Cell cell in row.Elements<Cell>())
                    {
                        if (cell.DataType == null && cell.CellValue != null)
                        {
                             // Check for pure numbers
                             Console.WriteLine(cell.CellValue.Text);
                        }
                         else if (cell.DataType.Value == CellValues.Boolean)
                        {
                             // Booleans
                             Console.WriteLine(cell.CellValue.Text);
                         }
                        else if (cell.CellValue != null)
                        {
                             // A shared string
                             if (stringtable != null)
                             {
                              // Cell value holds the shared string location
                              Console.WriteLine(stringtable.SharedStringTable.ElementAt(int.Parse(cell.CellValue.Text)).InnerText);
                             }
                         }
                         else { 
                               Console.WriteLine("A broken book");
                         }
                     }
                }
            }
       }
