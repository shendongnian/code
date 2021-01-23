            Excel.Application excel = new Excel.Application();
            Excel.Workbook workbook = excel.Workbooks.Open(@"c:\test.xls", Missing.Value, Missing.Value,
                                                           Missing.Value, Missing.Value, Missing.Value,
                                                           Missing.Value, Missing.Value, Missing.Value,
                                                           Missing.Value, Missing.Value, Missing.Value, false,
                                                           Missing.Value, Missing.Value);
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets[1];
            decimal dec = 12.5m;
            worksheet.get_Range("A1").Value = dec;
            DateTime date = DateTime.Now.Date;
            worksheet.get_Range("A2").Value = date;
            string str = "Hello";
            worksheet.get_Range("A3").Value = str;
            Marshal.FinalReleaseComObject(worksheet);
            workbook.Save();
            workbook.Close(false, Type.Missing, Type.Missing);
            Marshal.FinalReleaseComObject(workbook);
            excel.Quit();
            Marshal.FinalReleaseComObject(excel);
