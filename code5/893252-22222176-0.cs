    using Microsoft.Office.Interop.Excel;
    ....
    try
    {
        Application app = new Application();
        Workbook book = app.Workbooks.Open(@workbookPath); //@workbookpath is the file path
    }
    catch
    {
        //Excel encountered an error opening the file at the path
    }
