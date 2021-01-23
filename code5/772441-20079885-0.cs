    String content = "<html><body><table><tr><td>your table</td></tr></table></body></html>";
    Response.Clear();
    Response.AddHeader("Content-Disposition", "attachment;filename=" + filename + ".xls");
    Response.ContentType = "application/vnd.xls";
    Response.Cache.SetCacheability(HttpCacheability.NoCache); // not necessarily required
    Response.Charset = "";
    Response.Output.Write(content);
    Response.End();
