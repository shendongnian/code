        public interface IExternalUrlProvider
        {
            string DownloadString(string baseUrl, string path);
            string GetString(string baseUri, string relativePath, string userName, string password, AuthenticationSchemes scheme);
            string Post(string baseUri, string relativePath, string userName, string password, AuthenticationSchemes scheme = AuthenticationSchemes.Basic, Dictionary<string, object> postParameters = null);
        }
