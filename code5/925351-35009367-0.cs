    // Start a new workbook in Excel.
            var excel = new Microsoft.Office.Interop.Excel.Application { Visible = true };
            var excelWorkBooks = (Microsoft.Office.Interop.Excel.Workbooks)excel.Workbooks;
            var workbookAdd = (Microsoft.Office.Interop.Excel._Workbook)excelWorkBooks.Add(); // XlWBATemplate.xlWBATWorksheet
            var worksheets = (Microsoft.Office.Interop.Excel.Sheets)workbookAdd.Worksheets;
            var sheet = (Microsoft.Office.Interop.Excel._Worksheet)worksheets.Item[1];
            sheet.Visible = XlSheetVisibility.xlSheetVisible;
