    protected void Save_BtnClick(object sender, EventArgs e)
        {
 
            // Get the web page HTML as a string
            string htmlCodeToConvert = null;
            using (StringWriter sw = new StringWriter())
            {
                try
                {
                    System.Web.HttpContext.Current.Server.Execute("Receipt.aspx", sw);
                    htmlCodeToConvert = sw.ToString();
 
                }
                catch (Exception ex)
                {
                    // set breakpoint below and on an exception see if there is an inner exception.
                    throw;                    
                }
            }
 
            PdfConverter converter = new PdfConverter();
            // Supply auth cookie to converter
            converter.HttpRequestCookies.Add(System.Web.Security.FormsAuthentication.FormsCookieName,
                Request.Cookies[System.Web.Security.FormsAuthentication.FormsCookieName].Value);
 
            // baseurl is used by converter when it gets CSS and image files
            string baseUrl = Request.Url.Scheme + "://" + Request.Url.Authority +
                Request.ApplicationPath.TrimEnd('/') + "/";
 
            // create the PDF and get as bytes
            byte[] pdfBytes = converter.GetPdfBytesFromHtmlString(htmlCodeToConvert, baseUrl);
 
            // Stream bytes to user
            Response.Clear();
            Response.AppendHeader("Content-Disposition", "attachment;filename=Receipt.pdf");
            Response.ContentType = "application/pdf";
            Response.OutputStream.Write(pdfBytes, 0, pdfBytes.Length);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
 
        }
