    public static class HtmlClientSideValidationExtensions
        {
            public static IDisposable BeginAjaxContentValidation(this HtmlHelper html, string formId)
            {
                MvcForm mvcForm = null;
    
                if (html.ViewContext.FormContext == null)
                {
                    html.EnableClientValidation();
                    mvcForm = new MvcForm(html.ViewContext);
                    html.ViewContext.FormContext.FormId = formId;
                }
    
                return new AjaxContentValidation(html.ViewContext, mvcForm);
            }
    
            private class AjaxContentValidation : IDisposable
            {
                private readonly MvcForm _mvcForm;
                private readonly ViewContext _viewContext;
    
                public AjaxContentValidation(ViewContext viewContext, MvcForm mvcForm)
                {
                    _viewContext = viewContext;
                    _mvcForm = mvcForm;
                }
    
                public void Dispose()
                {
                    if (_mvcForm != null)
                    {
                        _viewContext.OutputClientValidation();
                        _viewContext.FormContext = null;
                    }
                }
            }
        }
    
        public static class CollectionValidation
        {
    
            private const string idsToReuseKey = "__htmlPrefixScopeExtensions_IdsToReuse_";
    
            public static IDisposable BeginCollectionItem(this HtmlHelper html, string collectionName)
            {
                var idsToReuse = GetIdsToReuse(html.ViewContext.HttpContext, collectionName);
                string itemIndex = idsToReuse.Count > 0 ? idsToReuse.Dequeue() : Guid.NewGuid().ToString();
    
                // autocomplete="off" is needed to work around a very annoying Chrome behaviour whereby it reuses old values after the user clicks "Back", which causes the xyz.index and xyz[...] values to get out of sync.
                html.ViewContext.Writer.WriteLine(string.Format("<input type=\"hidden\" name=\"{0}.index\" autocomplete=\"off\" value=\"{1}\" />", collectionName, html.Encode(itemIndex)));
    
                return BeginHtmlFieldPrefixScope(html, string.Format("{0}[{1}]", collectionName, itemIndex));
            }
    
            public static IDisposable BeginHtmlFieldPrefixScope(this HtmlHelper html, string htmlFieldPrefix)
            {
                return new HtmlFieldPrefixScope(html.ViewData.TemplateInfo, htmlFieldPrefix);
            }
    
            private static Queue<string> GetIdsToReuse(HttpContextBase httpContext, string collectionName)
            {
                // We need to use the same sequence of IDs following a server-side validation failure,  
                // otherwise the framework won't render the validation error messages next to each item.
                string key = idsToReuseKey + collectionName;
                var queue = (Queue<string>)httpContext.Items[key];
                if (queue == null)
                {
                    httpContext.Items[key] = queue = new Queue<string>();
                    var previouslyUsedIds = httpContext.Request[collectionName + ".index"];
                    if (!string.IsNullOrEmpty(previouslyUsedIds))
                        foreach (string previouslyUsedId in previouslyUsedIds.Split(','))
                            queue.Enqueue(previouslyUsedId);
                }
                return queue;
            }
    
            private class HtmlFieldPrefixScope : IDisposable
            {
                private readonly TemplateInfo templateInfo;
                private readonly string previousHtmlFieldPrefix;
    
                public HtmlFieldPrefixScope(TemplateInfo templateInfo, string htmlFieldPrefix)
                {
                    this.templateInfo = templateInfo;
    
                    previousHtmlFieldPrefix = templateInfo.HtmlFieldPrefix;
                    templateInfo.HtmlFieldPrefix = htmlFieldPrefix;
                }
    
                public void Dispose()
                {
                    templateInfo.HtmlFieldPrefix = previousHtmlFieldPrefix;
                }
            }
        }
