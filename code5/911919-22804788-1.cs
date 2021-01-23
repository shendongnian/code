    using (ExcelPackage package = new ExcelPackage(file))
    {
        ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("test");
    
        worksheet.Cells["A1"].LoadFromCollection(myColl, true, OfficeOpenXml.Table.TableStyles.Medium);
    
        package.Save();
    }
