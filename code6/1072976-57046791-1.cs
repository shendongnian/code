        string filePath = @"P:\Visual Studio 2013\Projects\Debugging\Debugging\test.htm";
        string savePath = @"P:\Visual Studio 2013\Projects\Debugging\Debugging\testing.xls";
        var excelApp = new Excel.Application()
        {
            Visible = true      //This is optional
        };
        Workbooks workbook = excelApp.Workbooks;
        workbook.Open(filePath);
        Range range = excelApp.get_Range("A9:B15");
        range.Copy();
        excelApp.ActiveSheet.Range("A1").PasteSpecial(Transpose: true);     //voila... :)
        range.Delete(XlDeleteShiftDirection.xlShiftToLeft);     //delete original range 
        if (!System.IO.File.Exists(savePath))           //is the workbook already saved?
        {
            excelApp.ActiveWorkbook.SaveAs(savePath);   //save
        }
        else
        {
            Console.WriteLine("File \"{0}\" already exists.", savePath);    //or do whatever...
            Console.ReadLine();
            return;
        }
