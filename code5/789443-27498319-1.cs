    string path = Server.MapPath(@"../../../Ex/template.xlsx")
    try
    {
        OfficeOpenXml.ExcelPackage pck = getSheet(path);
        Response.Clear();
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", String.Format(System.Globalization.CultureInfo.InvariantCulture, "attachment; filename={0}", fileName + ".xlsx"));
        Response.BinaryWrite(pck.GetAsByteArray());
        Response.End();
    }
    catch { }
