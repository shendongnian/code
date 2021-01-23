    public class QueryableSelectAttribute : ActionFilterAttribute
    {
        private const string ODataSelectOption = "$select=";
        private string selectValue;
        public QueryableSelectAttribute(string select)
        {
            this.selectValue = select;
        }
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            base.OnActionExecuting(actionContext);
            var request = actionContext.Request;
            var query = request.RequestUri.Query.Substring(1);
            var parts = query.Split('&').ToList();
            for (int i = 0; i < parts.Count; i++)
            {
                string segment = parts[i];
                if (segment.StartsWith(ODataSelectOption, StringComparison.Ordinal))
                {
                    parts.Remove(segment);
                    break;
                }
            }
            parts.Add(ODataSelectOption + this.selectValue);
            var modifiedRequestUri = new UriBuilder(request.RequestUri);
            modifiedRequestUri.Query = string.Join("&", parts.Where(p => p.Length > 0));
            request.RequestUri = modifiedRequestUri.Uri;
            base.OnActionExecuting(actionContext);
        }
    }
