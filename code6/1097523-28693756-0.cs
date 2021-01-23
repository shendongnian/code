    for (int valueNum = 0; valueNum < bug.Fields["Microsoft.VSTS.Common.CrimsonLogic.TargetVersion"].AllowedValues.Count; valueNum++)
    {
        //use unused columns to add validation value
        xlWorkSheet.Cells[valueNum + 1, 27] = bug.Fields["Microsoft.VSTS.Common.CrimsonLogic.TargetVersion"].AllowedValues[valueNum].ToString();
    }
    //Column R is where I want the drop down list to be
    ValidationValueCol = xlWorkSheet.UsedRange.Columns["R:R", Type.Missing];
    ValidationValueCol.Validation.Delete();
    strconfig = "='" + Sheetname+ "'!$AA$1:$AA$" + (bug.Fields["Microsoft.VSTS.Common.CrimsonLogic.TargetVersion"].AllowedValues.Count+1);
    //Add the validation range with the pre-stored list
    ValidationValueCol.Validation.Add(XlDVType.xlValidateList, XlDVAlertStyle.xlValidAlertStop, XlFormatConditionOperator.xlBetween, strconfig, Type.Missing);
    ValidationValueCol.Validation.IgnoreBlank = true;
    HideColumn(xlWorkSheet, "AA");
