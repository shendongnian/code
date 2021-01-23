    using (var package = new ExcelPackage(new MemoryStream(GetBytesTemplate(FullyQualifiedApplicationPath + "Content/excelTemplates/Format.xlsx"))))
        {
            //Write data to excel
    
            //Read file like byte array to return a response
            Response.Clear();
            Response.ContentType = "application/xlsx";
            Response.AddHeader("content-disposition", "attachment; filename=" + "myFileName" + ".xlsx");
            Response.BinaryWrite(package.GetAsByteArray());
            Response.End();
        }
