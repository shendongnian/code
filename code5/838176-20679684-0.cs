    public static class ValidationExtensions
    {
            public static MvcHtmlString AddCustomValidationSummary(this HtmlHelper htmlHelper)
            {
                string result = "";
    
                if (htmlHelper.ViewData.ModelState[""] != null && htmlHelper.ViewData.ModelState[""].Errors.Any())
                {
                    result = "<div class='note note-danger'><h4 class='block'>Errors</h4><p>" + htmlHelper.ValidationSummary().ToString() + "</p></div>";
                }
    
                return new MvcHtmlString(result);
            }
    }
