        string filePath = @"P:\Visual Studio 2013\Projects\Debugging\Debugging\test.htm";
        var excelApp = new Excel.Application()
        {
            Visible = true  //This is optional
        };
        Workbooks workbook = excelApp.Workbooks;
        workbook.Open(filePath);
        Range range = excelApp.get_Range("A9:B15");
        range.Copy();
        excelApp.ActiveSheet.Range("A1").PasteSpecial(Transpose: true); //voila... :)
        range.Delete(XlDeleteShiftDirection.xlShiftToLeft); //delete original range
        excelApp.ActiveWorkbook.SaveAs(@"P:\Visual Studio 2013\Projects\Debugging\Debugging\testing.xls");
  
