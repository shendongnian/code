    private static string ConvertUrlsToAbsolute(string baseUrl, string content) {
        if (string.IsNullOrWhiteSpace(content)) {
            return content;
        }
        var regex = new Regex("url\\(['\"]?(?<url>[^)]+?)['\"]?\\)");
        return regex.Replace(content, match => string.Concat("url(", RebaseUrlToAbsolute(baseUrl, match.Groups["url"].Value), ")"));
    }
    public string Process(string includedVirtualPath, string input) {
        if (includedVirtualPath == null) {
            throw new ArgumentNullException("includedVirtualPath");
        }
        var directory = VirtualPathUtility.GetDirectory(includedVirtualPath);
        return ConvertUrlsToAbsolute(directory, input);
    }
    private static string RebaseUrlToAbsolute(string baseUrl, string url) {
        if (string.IsNullOrWhiteSpace(url) || string.IsNullOrWhiteSpace(baseUrl) || url.StartsWith("/", StringComparison.OrdinalIgnoreCase)) {
            return url;
        }
        if (!baseUrl.EndsWith("/", StringComparison.OrdinalIgnoreCase)) {
            baseUrl = string.Concat(baseUrl, "/");
        }
        return VirtualPathUtility.ToAbsolute(string.Concat(baseUrl, url));
    }
