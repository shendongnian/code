    public class GlobalizationViewEngine : RazorViewEngine
    {
        protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath)
        {
            partialPath = GlobalizeViewPath(controllerContext, partialPath);
            return new RazorView(controllerContext, partialPath, null, false, FileExtensions, ViewPageActivator);
        }
        protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath)
        {
            viewPath = GlobalizeViewPath(controllerContext, viewPath);
            return base.CreateView(controllerContext, viewPath, masterPath);
        }
        private static string GlobalizeViewPath(ControllerContext controllerContext, string viewPath)
        {
            var request = controllerContext.HttpContext.Request;
            string cultureName = null;
            HttpCookie cultureCookie = request.Cookies["_culture"];
            if (cultureCookie != null)
                cultureName = cultureCookie.Value;
            else
                cultureName = request.UserLanguages != null && request.UserLanguages.Length > 0 ?
                        request.UserLanguages[0] :  // obtain it from HTTP header AcceptLanguages
                        null;
            // Validate culture name
            cultureName = CultureHelper.GetImplementedCulture(cultureName); // This is safe
            var lang = (CultureInfo.CreateSpecificCulture(cultureName)).TwoLetterISOLanguageName; // this is to extract the two languge letters from the culture
            if (lang != null &&
                !string.IsNullOrEmpty(lang) &&
                !string.Equals(lang, "en", StringComparison.InvariantCultureIgnoreCase))
            {
                string localizedViewPath = Regex.Replace(
                    viewPath,
                    "^~/Views/",
                    string.Format("~/Views/Globalization/{0}/",
                    lang
                    ));
                if (File.Exists(request.MapPath(localizedViewPath)))
                { viewPath = localizedViewPath; }
            }
            return viewPath;
        }
    }
