    Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
    Microsoft.Office.Interop.Excel.Workbook myWorkbook = excelApp.Workbooks.Open(path);
    Microsoft.Office.Interop.Excel.Names wbNames = myWorkbook.Names;
    foreach (Name n in wbNames)
    {
                    System.Windows.Forms.MessageBox.Show(n.Name);
    }
