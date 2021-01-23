     protected void Page_Load(object sender, EventArgs e)
        {
    
            Page.Response.ContentType = "text/xml";
            System.IO.StreamReader reader = new System.IO.StreamReader(Page.Request.InputStream);
            String xml = reader.ReadToEnd();
            String xmlData = HttpUtility.UrlDecode(xml);
            System.Diagnostics.Debug.WriteLine(xmlData);
    
        }
