    static void Main(string[] args)
            {
                    const string folderLocation = @"\\c:\elmah-exceptions\";
                    var ElasticSearchServerURI = "http://localhost:9200";
                    var defaultIndex = "prod";
                    var uri = new Uri(ElasticSearchServerURI);
                    var connectionSettings = new ConnectionSettings(uri, defaultIndex).EnableTrace(true).ExposeRawResponse(true);
                    var elasticClient = new ElasticClient(connectionSettings);
    
                    var files = GetFiles(folderLocation);
                    foreach (var file in files)
                    {
                        var error = ParseFile(file);
                        if (error != null)
                        {
                            elasticClient.Index(error);//I get an error on this line
                        }
                    }         
            }
    
    public class Error
        {
            public string errorType { get; set; }
            public string message { get; set; }
            public string source { get; set; }
            public string errorArea { get; set; }
    
            public string queryString { get; set; }
            public string siteId { get; set; }
            public string model { get; set; }
            public string eolUserName { get; set; }
            public string name { get; set; }
    
            public string httpClientSrcIP { get; set; }
            public string errorTime { get; set; }
            public string sessionId { get; set; }
            public string httpSoapAction { get; set; }
            public string pathTranslated { get; set; }
            public string httpReferer { get; set; }
    
            public string sessionStartQueryString { get; set; }
    
            public string file { get; set; }
            public string host { get; set; }
        }
