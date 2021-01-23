        ...
            try {
                HttpClientHandler httpClientHandler = new HttpClientHandler();
                httpClientHandler.AllowAutoRedirect = false;
                httpClientHandler.Credentials = new NetworkCredential(caldavuserTB.Text, caldavpasswordTB.Text);
                HttpClient httpClient = new HttpClient(httpClientHandler);
                httpClient.MaxResponseContentBufferSize = 256000;
                propfindMethod = new HttpMethod("PROPFIND");
                propfindHttpRequestMessage = new HttpRequestMessage(propfindMethod, webURLAsURI);
                propfindHttpRequestMessage.Headers.Add("Prefer", "return-minimal");
                propfindHttpRequestMessage.Headers.Add("Depth", "0");
                propfindHttpRequestMessage.Headers.Add("Accept", "application/xml; charset=utf-8");
                propfindHttpRequestMessage.Content = new StringContent("<d:propfind xmlns:d=\"DAV:\" xmlns:cs=\"http://calendarserver.org/ns/\"><d:prop><d:displayname /><cs:getctag /></d:prop></d:propfind>");
                
                propfindHttpResponseMesage = await httpClient.SendAsync(propfindHttpRequestMessage);
            }
        ...
