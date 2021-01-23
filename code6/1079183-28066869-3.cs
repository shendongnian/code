    System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
      response.Clear();
      response.Buffer = true;
      response.Charset = "";
      response.ContentType = "application/vnd.openxmlformats-     officedocument.spreadsheetml.sheet";
      response.AddHeader("content-disposition", "attachment;filename=ExcelData.xlsx");
      response.BinaryWrite(package.GetAsByteArray());
