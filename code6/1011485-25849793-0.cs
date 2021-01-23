    public class BundleTokenController : ApiController
    {
        public string Get(string path)
        {
            var url = System.Web.Optimization.Scripts.Url(path).ToString(); 
            //This will return relative url of the script bundle with querystring
            if (!url.Contains("?"))
            {
                url = System.Web.Optimization.Styles.Url(path).ToString(); 
                //If it's not a script bundle, check if it's a css bundle
            }
            if (!url.Contains("?"))
            {
                throw new Exception("Invalid path"); 
                //If neither, the path is invalid, 
                //or something going wrong with your bundle config, 
                //do error handling correspondingly
            }
            return GetTokenFromUrl(url);
        }
        private static string GetTokenFromUrl(string url)
        {
            //Just a raw way to extract the 'v' token from the relative url, 
            //there can be other ways
            var querystring = url.Split('?')[1];
            return HttpUtility.ParseQueryString(querystring)["v"];
        }
    }
