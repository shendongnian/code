    var activeBook = (Workbook)currentInstance.ActiveWorkbook;
    Range rnArea = activeSheet.Range["A1:A1"];
    activeBook.Names.Add("TESTNAME", rnArea);
    rnArea = activeSheet.Range["B1:B1"];
    activeSheet.Names.Add("TESTNAME", rnArea);
    
    List<Name> existingNamedRangeList1 = XlHelper.GetNamedRanges(currentInstance.ActiveWorkbook);
    foreach (Name RangeName in existingNamedRangeList1)
    {
        if (RangeName.Value.Contains("#REF!"))
        {
            RangeName.Delete();
        }
    }
