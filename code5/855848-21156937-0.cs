    String FileName = tbl.Rows[0][0].ToString();
    String FilePath = "C:/...."; //Replace this
    System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
    response.ClearContent();
    response.Clear();
    response.ContentType = "text/plain";
    response.AddHeader("Content-Disposition", "attachment; filename=" + FileName + ";");
    response.TransmitFile(FilePath);
    response.Flush();
    response.End();
