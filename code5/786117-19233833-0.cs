    if(File.Exists("C:/file.csv"))
    {
        ModifyExcel();
    }
    else
    {
        CreateExcel();
    }
---
    private void ModifyExcel()
    {
        oWB = (Excel._Workbook)(excelApp.Workbooks.Open(myPath));
    
                excelApp.Visible = false;
                excelApp.Cells[rowIndex, colIndex] = "IN TRY METHOD";
                oWB.Save();
                oWB.Close();
    }
    
    private void CreateExcel()
    {
        oWB = (Excel._Workbook)(excelApp.Workbooks.Add(System.Reflection.Missing.Value));
                excelApp.Visible = false;
                excelApp.Cells[rowIndex, colIndex] = "IN CATCH METHOD";
                oWB.SaveAs(myPath);
                oWB.Close();
    }
