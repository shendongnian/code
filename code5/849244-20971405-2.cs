    // urls[0] known host, unknown document
    // urls[1] unknown host
    var urls = new string[] { "http://www.example.com/abcdrandom.html", "http://www.abcdrandom.eu" };
    using (HttpClient client = new HttpClient())
    {
        HttpResponseMessage response = new HttpResponseMessage();
        foreach (var url in urls)
        {
            Console.WriteLine("Attempting to fetch " + url);
            try
            {
                response = await client.GetAsync(url);
                // If we get here, we have a response: we reached the host
                switch (response.StatusCode)
                {
                    case System.Net.HttpStatusCode.OK:
                    case System.Net.HttpStatusCode.NotFound: { /* handle 200 & 404 */ } break;
                    default: { /* whatever */ } break;
                }
            }
            catch (HttpRequestException ex)
            {
                //kept to a bare minimum for shortness
                var inner = ex.InnerException as WebException;
                if (inner != null)
                {
                    switch (inner.Status)
                    {
                        case WebExceptionStatus.NameResolutionFailure: { /* host not found! */ } break;
                        default: { /* other */ } break;
                    }
                }
            }
        }
    }
