    public class ExcelClient : IDisposable
    {
        public ExcelClient(Uri webUri, ICredentials credentials)
        {
            WebUri = webUri;
            _client = new WebClient {Credentials = credentials};
        }
        public string ReadRange(string libraryName, string fileName,string rangeName, string formatType)
        {
            var endpointUrl = WebUri + string.Format("/_vti_bin/ExcelRest.aspx/{0}/{1}/Model/Ranges('{2}')?$format={3}", libraryName,fileName, rangeName, formatType);
            return _client.DownloadString(endpointUrl);
        }
        public void Dispose()
        {
            _client.Dispose();
            GC.SuppressFinalize(this);
        }
        public Uri WebUri { get; private set; }
        private readonly WebClient _client;
    }
