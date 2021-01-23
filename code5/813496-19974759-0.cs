    object misValue = System.Reflection.Missing.Value;
    
    Microsoft.Office.Interop.Excel.Range xlRange = xlWorkSheet.get_Range("A2", "A2");
    
    Microsoft.Office.Interop.Excel.Range xlFound = xlRange.EntireRow.Find("ID Number",
    misValue, Excel.XlFindLookIn.xlValues, Excel.XlLookAt.xlPart,
    Excel.XlSearchOrder.xlByColumns, Excel.XlSearchDirection.xlNext, 
    true, misValue, misValue);
    
    //~~> Check if a range was returned
    if (!(xlFound == null))
    {
        int ID_Number = xlFound.Column;
        MessageBox.Show(ID_Number.ToString());
    }
