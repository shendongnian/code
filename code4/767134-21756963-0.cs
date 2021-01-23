            Excel.Application oXL;
            Excel._Workbook dataB;
            Excel._Worksheet dataS;
            Excel.Range oResizeRange;
            string path = pathToCSV;
            oXL = new Excel.Application();
            dataB = oXL.Workbooks.Open(path, 0,
            false, 5, Missing.Value, Missing.Value, false, Missing.Value, Missing.Value,
            false, false,Missing.Value, false, false, false);
            dataB.Application.DisplayAlerts = false;
            oXL.Visible = true;
            dataS = (Excel._Worksheet)dataB.ActiveSheet;
         
            dataS.get_Range("A1",("A" +   
            dataS.UsedRange.Rows.Count)).TextToColumns(Type.Missing, 
            Microsoft.Office.Interop.Excel.XlTextParsingType.xlDelimited, 
            Microsoft.Office.Interop.Excel.XlTextQualifier.xlTextQualifierNone, true,
            Type.Missing,Type.Missing, false, true, Type.Missing,
            " ", Type.Missing, Type.Missing, Type.Missing, Type.Missing);
