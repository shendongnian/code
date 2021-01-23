     string fileName = "SVGSample01.svg";
     string URL = "file:///D:/MySVGFiles 1/";
     
     StringWriter stringWriter = new StringWriter();
        using (HtmlTextWriter writer = new HtmlTextWriter(stringWriter))
        {
            writer.AddAttribute(HtmlTextWriterAttribute.Src, fileName);
            writer.AddAttribute(HtmlTextWriterAttribute.Width, "50%");
            writer.AddAttribute(HtmlTextWriterAttribute.Height, "50%");
            writer.RenderBeginTag(HtmlTextWriterTag.Img); 
            writer.RenderEndTag(); 
        }
        string content = stringWriter.ToString();
     (this.webKitBrowser1.GetWebView() as IWebView).mainFrame().loadHTMLString(content,URL);
