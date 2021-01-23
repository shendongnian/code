    public static void CreateSpreadsheetWorkbook(string filepath)
        {
            using (SpreadsheetDocument spreadSheetDocument = SpreadsheetDocument.Open(filepath, false))
            {
                WorkbookPart wbPart = spreadSheetDocument.WorkbookPart;
                foreach (Sheet sheet in wbPart.Workbook.Sheets)
                {
                    WorksheetPart wsPart = (WorksheetPart)(wbPart.GetPartById(sheet.Id));
                    OpenXmlReader reader = OpenXmlReader.Create(wsPart);
                    while (reader.Read())
                    {
                        Worksheet wsPartXml = (Worksheet)reader.LoadCurrentElement();
                        Console.WriteLine(wsPartXml.OuterXml);
                        Console.WriteLine("\n");
                    }
                }
                Console.ReadKey();
            }
        }
