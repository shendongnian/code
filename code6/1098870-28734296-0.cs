        //open the file
        using (SpreadsheetDocument myDoc = SpreadsheetDocument.Open(path, true))
        {
            //workbook part captcure
            WorkbookPart workbookPart = myDoc.WorkbookPart;
            //then access to the worksheet part
            IEnumerable<WorksheetPart> worksheetPart = workbookPart.WorksheetParts;
            foreach (WorksheetPart WSP in worksheetPart)
            {
                //find sheet data
                IEnumerable<SheetData> sheetData = WSP.Worksheet.Elements<SheetData>();
                foreach (SheetData SD in sheetData)
                {
                    foreach (Row r in SD.Elements<Row>())
                    {
                        foreach (Cell c in r.Elements<Cell>())
                        {
                            string text = c.CellValue.Text;
                            Console.WriteLine(text);
                        }
                    }
                    Console.ReadKey();
                }
            }
        }
