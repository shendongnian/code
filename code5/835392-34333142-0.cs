        private Microsoft.Office.Interop.Excel.Application xla;
        Workbook wb;
        Worksheet ws;
        Range rg;
        ..........
            xla = new Microsoft.Office.Interop.Excel.Application();
            wb = xla.Workbooks.Add(XlSheetType.xlWorksheet);
            ws = (Worksheet)xla.ActiveSheet;
            rg = (Range)ws.Cells[1, 2];
            rg.ColumnWidth = 10;
            rg.Value2 = "Frequency";
            rg = (Range)ws.Cells[1, 3];
            rg.ColumnWidth = 15;
            rg.Value2 = "Impudence";
            rg = (Range)ws.Cells[1, 4];
            rg.ColumnWidth = 8;
            rg.Value2 = "Phase";
