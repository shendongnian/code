    using (var fsOut = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
        using (var stringReader = new StringReader(result))
        {
            var document = new Document();
            var pdfWriter = PdfWriter.GetInstance(document, fsOut);
            pdfWriter.InitialLeading = 12.5f;
            document.Open();
            var xmlWorkerHelper = XMLWorkerHelper.GetInstance();
            var cssResolver = new StyleAttrCSSResolver();
            var xmlWorkerFontProvider = new XMLWorkerFontProvider();
            foreach (string font in fonts)
            {
                xmlWorkerFontProvider.Register(font);
            }
            var cssAppliers = new CssAppliersImpl(xmlWorkerFontProvider);
            var htmlContext = new HtmlPipelineContext(cssAppliers);
            htmlContext.SetTagFactory(Tags.GetHtmlTagProcessorFactory());
            PdfWriterPipeline pdfWriterPipeline = new PdfWriterPipeline(document, pdfWriter);
            HtmlPipeline htmlPipeline = new HtmlPipeline(htmlContext, pdfWriterPipeline);
            CssResolverPipeline cssResolverPipeline = new CssResolverPipeline(cssResolver, htmlPipeline);
            XMLWorker xmlWorker = new XMLWorker(cssResolverPipeline, true);
            XMLParser xmlParser = new XMLParser(xmlWorker);
            xmlParser.Parse(stringReader);
            document.Close();
        }
    }
