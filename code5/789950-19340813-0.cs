        @Html.ActionMenuItem(
            "All Reports", 
            "index", 
            "report", 
            "icon-bar-chart", 
            "last", 
            new Dictionary<string, string>[]
            {
                new Dictionary<string, string>()
                {
                    { "title", "Report 1" }, 
                    { "action", "report1" }
                }, 
                new Dictionary<string, string>()
                {
                    { "title",  "Report 2" },
                    { "action", "report2" }
                }
            } )
        public static MvcHtmlString ActionMenuItem(
            this HtmlHelper htmlHelper, 
            string linkText, 
            string actionName, 
            string controllerName, 
            string iconType = null, 
            string classCustom = null, 
            params Dictionary<string, string>[] subMenu)
