     HttpContext context = HttpContext.Current;
     context.Response.Clear();
     context.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1254");
     context.Response.Charset = "windows-1254";
     context.Response.ContentType = "application/vnd.ms-excel";
     context.Response.AppendHeader("content-disposition", string.Format("attachment;filename={0}.xls", fileName));
     context.Response.Flush();
     context.Response.End();
