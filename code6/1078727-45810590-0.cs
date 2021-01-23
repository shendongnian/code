        public static bool IsValidUrl(string url)
        {
            if (url == null)
            {
                return false;
            }
            try
            {
                Uri uriResult = new Uri(url);
                return Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute);
            }
            catch
            {
                return false;
            }
        }
