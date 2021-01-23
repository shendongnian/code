    public static IHtmlString RenderActionToSpecifiedAssembly(this HtmlHelper helper, string actionName, string controllerName, string parentAssembly)
    {
            var parentWebConfigarentValue = new Uri(ConfigurationManager.AppSettings[parentAssembly]);
            var path = controllerName + "/" + actionName;
            var redirect = new Uri(parentWebConfigarentValue, path).AbsoluteUri;
            var request = (HttpWebRequest)WebRequest.Create(redirect);
            var result = (HttpWebResponse)request.GetResponse();
            String responseString;
            using (Stream stream = result.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                responseString = reader.ReadToEnd();
            }
            return new HtmlString(responseString);
    }
