    using System.Linq;
    using System.Collections.Generic;
    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Spreadsheet;
    
    class Test
    {
    
        static void Main()
        {
            string filePath = @"C:\MyProtectedSheet.xlsx";
            using (var spreadSheetDocument = SpreadsheetDocument.Open(filePath, true))
            {
                var workbookPart = spreadSheetDocument.WorkbookPart;
                var sheets = spreadSheetDocument.WorkbookPart.Workbook.GetFirstChild<Sheets>().Elements<Sheet>();
                string relationshipId = sheets.First().Id.Value;
                var worksheetPart = (WorksheetPart)spreadSheetDocument.WorkbookPart.GetPartById(relationshipId);
                var workSheet = worksheetPart.Worksheet;
                var protections = worksheet.Elements<SheetProtection>(); 
                
                if(protections.Any())) {
                    Console.WriteLine("Sheet is protected.");
                }
            }
        }
    }
