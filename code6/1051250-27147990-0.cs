        HttpContext.Current.Response.Clear();  
     HttpContext.Current.Response.Charset = "";  
     HttpContext.Current.Response.ContentType = "application/msword";  
     string strFileName = "docName" + ".doc";  
     HttpContext.Current.Response.AddHeader("Content-Disposition", "inline;filename=" + strFileName);  
     StringBuilder strHTMLContent = new StringBuilder();  
     strHTMLContent.Append(htmlContent); 
    
 
     HttpContext.Current.Response.Write(strHTMLContent);  
     HttpContext.Current.Response.End();  
     HttpContext.Current.Response.Flush();  
