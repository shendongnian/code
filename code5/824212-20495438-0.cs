    public class MyMinifier
    {
        protected static Dictionary<string,List<string>> VirtualPathsInBundle
            = new Dictionary<string, List<string>>();
        protected static Dictionary<string, string> OriginalJavascriptInBundle
            = new Dictionary<string, string>();
        protected static Dictionary<string, string> MinifiedJavascriptInBundle
            = new Dictionary<string, string>();
        public static void AddBundle(string bundleName, params string[] virtualPaths)
        {
            VirtualPathsInBundle.Add(bundleName, virtualPaths.ToList());
        }
        public static string GetOriginalJavaScript(string bundleName)
        {
            if (!OriginalJavascriptInBundle.ContainsKey(bundleName))
            {
                var physicalFilePaths = VirtualPathsInBundle[bundleName]
                    .Select(vp => HttpContext.Current.Server.MapPath(vp));
                // If you use wildcards, expand them here...
                StringBuilder scripts = new StringBuilder();
                foreach (var path in physicalFilePaths)
                {
                    scripts.AppendFormat("// path: {0}", path);
                    scripts.AppendLine();
                    scripts.Append(File.ReadAllText(path));
                }
                OriginalJavascriptInBundle.Add(bundleName, scripts.ToString());
            }
            return OriginalJavascriptInBundle[bundleName];
        }
        public static string GetMinifiedJavaScript(string bundleName)
        {
            if (!MinifiedJavascriptInBundle.ContainsKey(bundleName))
            {
                Minifier minifier = new Minifier();
                MinifiedJavascriptInBundle[bundleName]
                    = minifier.MinifyJavaScript(GetOriginalJavaScript(bundleName));
            }
            return MinifiedJavascriptInBundle[bundleName];
        }
    }
