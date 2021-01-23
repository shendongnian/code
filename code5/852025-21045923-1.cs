        StringWriter sw = new StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
    
        StringReader sr;
        string fileName = Server.MapPath("PATH TO PDF");
    
        var doc = new Document(PageSize.A3, 45, 5, 5, 5);
        var pdf = fileName;
    
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(pdf,             FileMode.Create));
    
            doc.Open();
    
            HtmlPipelineContext htmlContext = new HtmlPipelineContext(null);
            htmlContext.SetTagFactory(Tags.GetHtmlTagProcessorFactory());
            ICSSResolver cssResolver = XMLWorkerHelper.GetInstance().GetDefaultCssResolver(false);
            
            cssResolver.AddCssFile(Server.MapPath("PATH TO CSS"), true);
            IPipeline pipeline = new CssResolverPipeline(cssResolver, new HtmlPipeline(htmlContext, new PdfWriterPipeline(doc, writer)));
            
            XMLWorker worker = new XMLWorker(pipeline, true);
            XMLParser xmlParse = new XMLParser(true, worker);
    
            control.RenderControl(htw);
            sr = new StringReader(sw.ToString());
            xmlParse.Parse(sr);
            xmlParse.Flush();
          
