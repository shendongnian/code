            var oMissing = Type.Missing;
            var excel = new Application();
            var wb = excel.Workbooks.Add(1);
            var sheet = wb.Sheets.Add();
            sheet.Name = "ClientEditSheet";
            sheet.Visible = false;
            sheet.Range["A1"].Value = "Name1";
            sheet.Range["A2"].Value = "Name2";
            sheet.Range["A3"].Value = "Name3";
            sheet.Range["A4"].Value = "Name4";
            var sheet2 = wb.Sheets["Sheet1"];
            Range validatingCellsRange = sheet2.Range["B1"].EntireColumn;
            var lookupValues = "=ClientEditSheet!$" + "A" + "$1:$" + "A" + "$14";
            validatingCellsRange.Validation.Delete();
            validatingCellsRange.Validation.Add(XlDVType.xlValidateList,
                   XlDVAlertStyle.xlValidAlertInformation,
                   XlFormatConditionOperator.xlBetween, lookupValues, Type.Missing);
            validatingCellsRange.Validation.IgnoreBlank = true;
            validatingCellsRange.Validation.InCellDropdown = true;
            //wb.Close(true);
            //excel.Quit();
            excel.Visible = true;
