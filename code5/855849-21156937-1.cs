    String FileName = tbl.Rows[0][0].ToString();
    String FilePath = "C:/...."; //Replace this
    System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
    response.ClearContent();
    response.Clear();
    response.ContentType = "text/plain";
    response.AddHeader("Content-Disposition", "attachment; filename=" + FileName + ";");
    byte[] blob = File.ReadAllBytes(FilePath );
    response.BinaryWrite(blob );
    response.Flush();
    response.End();
