    public static class HtmlHelpers
    {
        public static IHtmlString FirstModelError(this HtmlHelper html)
        {
            var modelState = html.ViewData.ModelState;
            if (modelState.IsValid)
            {
                return MvcHtmlString.Empty;
            }
            var span = new TagBuilder("span");
            string errorMessage = modelState
                .First(x => x.Value.Errors.Any())
                .Value
                .Errors
                .First()
                .ErrorMessage;
            span.SetInnerText(errorMessage);
            return new HtmlString(span.ToString());
        }
    }
