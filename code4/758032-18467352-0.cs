    string txtLocation = Path.GetFullPath(InputFile);
      
    object _missingValue = System.Reflection.Missing.Value;
    Microsoft.Office.Interop.Excel.Application excel = new   Microsoft.Office.Interop.Excel.Application();
    Excel.Workbook theWorkbook = excel.Workbooks.Open(txtLocation,
                                                            _missingValue,
                                                            false,
                                                            _missingValue,
                                                            _missingValue,
                                                            _missingValue,
                                                            true,
                                                            _missingValue,
                                                            _missingValue,
                                                            true,
                                                            _missingValue,
                                                            _missingValue,
                                                            _missingValue);
    //refresh and calculate to modify
    theWorkbook.RefreshAll();
    excel.Calculate();
    theWorkbook.Save();
    theWorkbook.Close(true);
    excel.Quit();
