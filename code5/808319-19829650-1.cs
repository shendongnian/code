    Excel.Range xlRng = (Excel.Range)workSheet.get_Range("A1:B6", Type.Missing);
    Dictionary<string, string> dic = new Dictionary<string, string>();
    foreach (Excel.Range cell in xlRng)
    {
                    
        string cellIndex = cell.get_AddressLocal(false, false, Excel.XlReferenceStyle.xlA1, Type.Missing, Type.Missing);
        string cellValue = Convert.ToString(cell.Value2);
        dic.Add(cellIndex, cellValue);
     }
