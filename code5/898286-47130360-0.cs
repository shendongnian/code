     string strPreviousPage = "";
         if (Request.UrlReferrer != null)
           {
            strPreviousPage = Request.UrlReferrer.Segments[Request.UrlReferrer.Segments.Length - 1];          
            }        
        if(strPreviousPage =="")
            {
              Response.Redirect("~/Login.aspx");
             }
