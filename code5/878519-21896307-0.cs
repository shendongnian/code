    private void CopySheet(int sNum, int pNum, string type)
    {
        var tempSheet = SpreadsheetDocument.Create(new MemoryStream(), SpreadsheetDocumentType.Workbook);
        WorkbookPart tempWBP = tempSheet.AddWorkbookPart();
        var part = Document.XGetWorkSheetPart(sNum);
        WorksheetPart tempWSP = tempWBP.AddPart<WorksheetPart>(part);
        var copy = Document.WorkbookPart.AddPart<WorksheetPart>(tempWSP);
        var sheets = Document.WorkbookPart.Workbook.GetFirstChild<Sheets>();
        var sheet = new Sheet();
        sheet.Id = Document.WorkbookPart.GetIdOfPart(copy);
        sheet.Name = "Phase " + pNum + " " + type;
        uint id = 1;
        bool valid = false;
        while (!valid)
        {
            uint temp = id;
            foreach (OpenXmlElement e in sheets.ChildElements)
            {
                var s = e as Sheet;
                if (id == s.SheetId.Value)
                {
                    id++;
                    break;
                }
            }
            if (temp == id)
                valid = true;
        }
        sheet.SheetId = id;
        sheets.Append(sheet);
    }
