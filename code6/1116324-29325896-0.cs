            System.Globalization.CultureInfo CurrentCI = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            **xlApp.FileValidation = MsoFileValidationMode.msoFileValidationSkip;** 
            xlWorkbook = xlApp.Workbooks.Open(@"C:\my file.xls");
            Excel.Sheets xlWorksheet = xlWorkbook.Worksheets;
            Excel.Worksheet worksheet = (Excel.Worksheet)xlWorksheet.get_Item(3);
            for (int i = 1; i <= 10; i++)
            {
                Excel.Range range = worksheet.get_Range("A" + i.ToString(), "B" + i.ToString()); ; //UsedRange;
                System.Array myvalues = (System.Array)range.Cells.Value2;
                             
                string[] strArray = ConvertToStringArray(myvalues);
                foreach (string item in strArray)
                {   
                    MessageBox.Show(item);
                }
            }
