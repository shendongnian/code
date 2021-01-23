        // Set css
        ICSSResolver cssResolver = XMLWorkerHelper.GetInstance().GetDefaultCssResolver(false);
        IPipeline pipeline = new CssResolverPipeline(cssResolver, new HtmlPipeline(htmlContext, new PdfWriterPipeline(document, writer)));
        cssResolver.AddCssFile(HttpContext.Server.MapPath("~/Content/bootstrap.css"), true);
        cssResolver.AddCss(".shadow {background-color: #ebdddd; }", true);
