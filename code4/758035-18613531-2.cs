    Application excel = (Application)Marshal.GetActiveObject("Excel.Application");
    Workbooks wbs = excel.Workbooks;
    foreach (Workbook wb in wbs)
    {
        Console.WriteLine(wb.Name); // print the name of excel files that are open
        wb.Save();
        wb.Close();
    }
    excel.Quit();
    
