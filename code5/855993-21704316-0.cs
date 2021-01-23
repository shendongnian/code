    public class RedirectResult : ActionResult
    {
        private string _url;
        public RedirectResult(string url)
        {
            _url = url;
        }
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            string url = UrlHelper.GenerateContentUrl(_url, context.HttpContext);
            context.Controller.TempData.Keep();
            HttpResponseBase response = context.HttpContext.Response;
            response.RedirectPermanent(url, endResponse: true);
        }
    }
