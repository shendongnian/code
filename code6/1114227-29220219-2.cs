    using Microsoft.Office.Interop.Excel;
    Application excelApp = new Application();
    Workbook myWorkbook = excelApp.Workbooks.Open(path);
    Names wbNames = myWorkbook.Names;
    foreach (Name n in wbNames)
    {
        System.Windows.Forms.MessageBox.Show(n.Name);
    }
