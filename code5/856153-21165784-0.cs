    using (var package = new OfficeOpenXml.ExcelPackage())
    {
        var sheet = package.Workbook.Worksheets.Add("Sheetname");
        sheet.Cells["A1"].LoadFromDataTable(tblData, true, OfficeOpenXml.Table.TableStyles.Medium6);
        var excelAttachment = new System.Net.Mail.Attachment(package.Stream, "Excelname");
        // ...
    }
