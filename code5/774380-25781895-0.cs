    var list = new System.Collections.Generic.List<string>();
    list.Add("RFP");
    list.Add("2nd Review");
    list.Add("RESHOOT");
    var flatList = string.Join(", ", list.ToArray());
                 
    var cell = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells.get_Range("B1");;
    cell.Validation.Delete();
    cell.Validation.Add( XlDVType.xlValidateList,
        XlDVAlertStyle.xlValidAlertInformation,
        XlFormatConditionOperator.xlBetween,
        flatList,
        Type.Missing);
