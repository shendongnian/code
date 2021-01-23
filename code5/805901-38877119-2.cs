    public string Process(string includedVirtualPath, string input)
        {
            if (includedVirtualPath == null)
            {
                throw new ArgumentNullException(nameof(includedVirtualPath));
            }
            if (string.IsNullOrWhiteSpace(input))
            {
                return input;
            }
            var directory = VirtualPathUtility.GetDirectory(includedVirtualPath);
            if (!directory.EndsWith("/", StringComparison.OrdinalIgnoreCase))
            {
                directory += "/";
            }
            return new Regex(@"url\s*\(\s*([\'""]?)(?<scheme>(?:(?:data:)|(?:https?:))?)(?<url>(\\\1|.)*?)\1\s*\)")
                .Replace(input, match => string.Concat(
                    "url(",
                    match.Groups[1].Value,
                    match.Groups["scheme"].Value,
                    match.Groups["scheme"].Value == "" ?
                        RebaseUrlToAbsolute(directory, match.Groups["url"].Value) :
                        match.Groups["url"].Value,
                    match.Groups[1].Value,
                    ")"
                ));
        }
        private static string RebaseUrlToAbsolute(string baseUrl, string url)
        {
            if (string.IsNullOrWhiteSpace(url) || string.IsNullOrWhiteSpace(baseUrl)
                || url.StartsWith("/", StringComparison.OrdinalIgnoreCase))
            {
                return url;
            }
            
            return VirtualPathUtility.ToAbsolute(string.Concat(baseUrl, url));
        }
    }
