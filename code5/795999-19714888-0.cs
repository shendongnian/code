    Excel.Application App = null;
    Excel.Workbook Book = null;
    Excel.Worksheet Sheet = null;
    object Missing = System.Reflection.Missing.Value;
    try
    {
        App = new Excel.Application();
        Book = App.Workbooks.Add();
        Sheet = (Excel.Worksheet) Book.Worksheets[1];
        Excel.Range Range = Sheet.get_Range("B2", "B2");
        Range.Validation.Add(Excel.XlDVType.xlValidateList
            , Excel.XlDVAlertStyle.xlValidAlertStop
            , Excel.XlFormatConditionOperator.xlBetween
            , "Item1,Item2,Item3"
            , Type.Missing);
        Range.Validation.InCellDropdown = true;
        Range.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 217, 217, 0)); 
        App.Visible = true;
    }
    finally
    {
        Base.ReleaseObject(Sheet);
        Base.ReleaseObject(Book);
        Base.ReleaseObject(App);
    }
