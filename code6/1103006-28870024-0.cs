     using (SpreadsheetDocument myDoc = SpreadsheetDocument.Open("PATH", true))
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
                int RowCount = 0;
                int CellCount = 0;
                // This is A1
                int RowMin = 1;
                int ColMin = 1;
                //This is E11              
                int RowMax = 11;
                int ColMax = 5;
                foreach (SheetData SD in sheetData)
                {
                    foreach (Row row in SD.Elements<Row>())
                    {
                        RowCount++; // We are in a new row
                        // For each cell we need to identify type
                        foreach (Cell cell in row.Elements<Cell>())
                        {
                            // We are in a new Cell
                            CellCount++;
                            if ((RowCount >= RowMin && CellCount >= ColMin) && (RowCount <= RowMax && CellCount <= ColMax))
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
                                else
                                {
                                    Console.WriteLine("A broken book");
                                }
                            }
                        }
                        // Reset Cell count
                        CellCount = 0;
                    }
                }
            }
        }
