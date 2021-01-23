        System.Web.HttpContext.Current.Response.Clear();
        System.Web.HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=DateTime.Now + ".xls");
        System.Web.HttpContext.Current.Response.Charset = "";
        
        Response.Cache.SetCacheability(HttpCacheability.NoCache);  // If you want the option to open the Excel file without saving than       
        System.Web.HttpContext.Current.Response.ContentType = "application/vnd.xls";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);        
        Gridview1.RenderControl(htmlWrite);
       
        //style to format numbers to string
        string style = @"<style> .textmode { } </style>";
        System.Web.HttpContext.Current.Response.Write(style);
        System.Web.HttpContext.Current.Response.Output.Write(stringWrite.ToString());
        System.Web.HttpContext.Current.Response.Flush();
        System.Web.HttpContext.Current.Response.End();  
