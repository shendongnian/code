    var cell = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[row, 8];
                cell.Validation.Delete();
                cell.Validation.Add(
                   XlDVType.xlValidateList,
                   XlDVAlertStyle.xlValidAlertInformation,
                   XlFormatConditionOperator.xlBetween,
                   flatList,
                   Type.Missing);
    
                cell.Validation.IgnoreBlank = true;
                cell.Validation.InCellDropdown = true;
