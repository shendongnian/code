    public static class ScriptBundleManager
    {
        private const string Key = "__ScriptBundleManager__";
        /// <summary>
        /// Call this method from your partials and register your script bundle.
        /// </summary>
        public static void Register(this HtmlHelper htmlHelper, string scriptBundleName)
        {
            //using a HashSet to avoid duplicate scripts.
            var set = htmlHelper.ViewContext.HttpContext.Items[Key] as HashSet<string>;
            if (set == null)
            {
                set = new HashSet<string>();
                htmlHelper.ViewContext.HttpContext.Items[Key] = set;
            }
            if (!set.Contains(scriptBundleName))
                set.Add(scriptBundleName);
        }
        /// <summary>
        /// In the bottom of your HTML document, most likely in the Layout file call this method.
        /// </summary>
        public static IHtmlString RenderScripts(this HtmlHelper htmlHelper)
        {
            var set = htmlHelper.ViewContext.HttpContext.Items[Key] as HashSet<string>;
            return set != null ? Scripts.RenderFormat("<script type=\"text/javascript\" src=\"{0}\"></script>", set.ToArray()) : MvcHtmlString.Empty;
        }
    }
