     xlWorkSheet.Range["$A$1"].Select();
     Range range = xlWorkSheet.get_Range("G2,G50");
     Validation v = range.Validation;
     // you might want to delete validation first
     // v.Delete();
     v.Add(XlDVType.xlValidateList, XlDVAlertStyle.xlValidAlertStop, XlFormatConditionOperator.xlBetween, "=$AM2:$AM50", System.Reflection.Missing.Value);
     // some other useful stuff for you
     // v.ErrorMessage = "You need to fill in a value from the validation list.";
     // v.InCellDropdown = true;
