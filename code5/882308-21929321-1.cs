        public ActionResult GetPage(int id)
        {
            var publishedContent = UmbracoContext.ContentCache.GetById(id);
            
            if (publishedContent == null || publishedContent.GetProperty("body") == null)
                return Content(@"Hmm, something went wrong. Unable to find what you're looking for.");
            if (UmbracoContext.PublishedContentRequest == null && Session["PublishedContentRequest"] == null)
                return RedirectToAction("CreatePublishedContentRequest", new { id });
            UmbracoContext.PublishedContentRequest = (PublishedContentRequest)Session["PublishedContentRequest"];
            Session["PublishedContentRequest"] = null;
            UmbracoContext.HttpContext.Items["pageID"] = id;
            return Content(GetHtmlContent(publishedContent));
        }
        [CreatePublishedContentRequestAttribute]
        public ActionResult CreatePublishedContentRequest(int id)
        {
            return RedirectToAction("GetPage", new { id });
        }
        private string GetHtmlContent(IPublishedContent publishedContent)
        {
            string content = publishedContent.GetProperty("body").Value.ToString();
            if (string.IsNullOrEmpty(content) || !content.Contains("UMBRACO_MACRO"))
                return content;
            int startIndex = content.IndexOf("macroAlias=") + 12;
            int length = content.LastIndexOf('"') - startIndex;
            var macroAlias = content.Substring(startIndex, length);
            return (Umbraco.RenderMacro(macroAlias) ?? new HtmlString("")).ToString();
        }
