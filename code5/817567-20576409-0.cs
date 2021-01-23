        public static MvcHtmlString BootstrapLinkButton(this HtmlHelper htmlHelper, 
            string linkText, 
            string actionName, 
            string controllerName = null, 
            object routeValues = null, 
            object htmlAttributes = null,
            string btnStyle = "default")
        {
            var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            controllerName = 
                controllerName ?? 
                HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
            if (attributes.ContainsKey("class"))
            {
                object value;
                attributes.TryGetValue("class", out value);
                value = string.Format("{0} btn btn-{1}", (value as string), btnStyle);
                attributes["class"] = value;
            }
            else
            {
                attributes["class"] = string.Format("btn btn-{0}", btnStyle);
            }
            return htmlHelper.ActionLink(
                linkText, 
                actionName, 
                controllerName, 
                HtmlHelper.AnonymousObjectToHtmlAttributes(routeValues), 
                new Dictionary<string, object>(attributes));
        }
    }
