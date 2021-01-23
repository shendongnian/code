            int row = 3;
            var wb = Globals.ThisAddIn.Application.ActiveWorkbook;
            ws.Range["A6"].Value = wb.Names.Count;
            foreach (Name rangeName in wb.Names)
            {
                Range c = ws.Cells[row++, 3];
                c.Value = rangeName.NameLocal;
            }
            var ws = Globals.ThisAddIn.Application.ActiveSheet;
            ws.Range["A7"].Value = ws.Range["MyRangeName"].Value;
