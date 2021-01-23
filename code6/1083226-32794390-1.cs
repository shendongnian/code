        // Set css
        ICSSResolver cssResolver = XMLWorkerHelper.GetInstance().GetDefaultCssResolver(false);
cssResolver.AddCssFile(HttpContext.Server.MapPath("~/Content/bootstrap.css"), true);
        cssResolver.AddCss(".shadow {background-color: #ebdddd; }", true);
        IPipeline pipeline = new CssResolverPipeline(cssResolver, new HtmlPipeline(htmlContext, new PdfWriterPipeline(document, writer)));
