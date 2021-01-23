    protected string getHTML(string url)
    {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                // ******  Add the this line! ****//
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
                // Set some reasonable limits on resources used by this request
                request.MaximumAutomaticRedirections = 4;
                request.MaximumResponseHeadersLength = 4;
                // Set credentials to use for this request.
                request.Credentials = CredentialCache.DefaultCredentials;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
    
                // Get the stream associated with the response.
                Stream receiveStream = response.GetResponseStream();
    
                // Pipes the stream to a higher level stream reader with the required encoding format. 
                StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
    
                string html = readStream.ReadToEnd();
                response.Close();
                readStream.Close();
                return html;
    }
