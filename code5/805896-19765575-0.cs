    private class ProperUrlRewrite : IItemTransform
    {
        private static string RebaseUrlToAbsolute(string baseUrl, string url)
        {
            if (string.IsNullOrWhiteSpace(url) || string.IsNullOrWhiteSpace(baseUrl) || url.StartsWith("/", StringComparison.OrdinalIgnoreCase) || url.Contains(':'))
                return url;
            return VirtualPathUtility.Combine(baseUrl, url);
        }
        private static Regex UrlPattern = new Regex("url\\s*\\(['\"]?(?<url>[^)]+?)['\"]?\\)");
        public string Process(string includedVirtualPath, string input)
        {
            if (includedVirtualPath == null)
                throw new ArgumentNullException("includedVirtualPath");
            if (string.IsNullOrWhiteSpace(input))
                return input;
            string directory = VirtualPathUtility.GetDirectory(VirtualPathUtility.ToAbsolute(includedVirtualPath));
            if (!directory.EndsWith("/", StringComparison.OrdinalIgnoreCase))
                directory += "/";
            return UrlPattern.Replace(input, match => "url(" + ProperUrlRewrite.RebaseUrlToAbsolute(directory, match.Groups["url"].Value) + ")");
        }
    }
