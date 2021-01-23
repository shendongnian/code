    private void runExcelWork()
    {
       //xlApp, xlBooks, xlWorksheet etc.. Is defined in this function
       //Do your work with Excel here.
       //Clean all excel objects here.
    }
    public void runExcel()
    {
       runExcelWork();
       //call GC
       GC.Collect();
       GC.WaitForPendingFinalizers();
       GC.Collect();
       //at this point EXCEL.EXE closes
    }
