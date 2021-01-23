    void Main()
    {
        string fileName = @"c:\temp\delete-row-openxml.xlsx";
        using (SpreadsheetDocument doc = SpreadsheetDocument.Open(fileName, true))
        {
            // Get the necessary bits of the doc
            WorkbookPart workbookPart = doc.WorkbookPart;
            SharedStringTablePart sstpart = workbookPart.GetPartsOfType<SharedStringTablePart>().First();
            SharedStringTable sst = sstpart.SharedStringTable;
		
            // Get the first worksheet
            WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();
            Worksheet sheet = worksheetPart.Worksheet;
            var rows = sheet.Descendants<Row>();
            foreach (Row row in rows.Where(r => ShouldDeleteRow(r, sst)))
            {
                row.Remove();
            }
        }
    }
    
    private bool ShouldDeleteRow(Row row, SharedStringTable sst)
    {
        // Whatever logic to apply to decide whether to remove a row or not
        string txt = GetCellText(row.Elements<Cell>().FirstOrDefault(), sst);
        return (txt == "Row 3");
    }
    // Basic way to get the text of a cell - need to use the SharedStringTable
    private string GetCellText(Cell cell, SharedStringTable sst)
    {
        if (cell == null)
            return "";
		
        if ((cell.DataType != null) && (cell.DataType == CellValues.SharedString))
        {
            int ssid = int.Parse(cell.CellValue.Text);
            string str = sst.ChildElements[ssid].InnerText;
            return str;
        }
        else if (cell.CellValue != null)
        {
            return cell.CellValue.Text;
        }
        return "";
    }
