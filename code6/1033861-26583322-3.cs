    Dim pck = New ExcelPackage();
    Dim ws = pck.Workbook.Worksheets.Add("Worksheet-Name");
    ws.Cells("A1").LoadFromDataTable(ds.Tables[0], True, OfficeOpenXml.Table.TableStyles.Medium1);
    Response.Clear();
    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
    Response.AddHeader("content-disposition", "attachment;  filename=ExcelFileName.xlsx");
    Response.BinaryWrite(pck.GetAsByteArray());
    Response.End();
