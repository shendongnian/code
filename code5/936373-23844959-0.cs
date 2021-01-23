       var httpClientHandler = new HttpClientHandler();
                            httpClientHandler.Credentials = new System.Net.NetworkCredential("username", "password");
                            var client = new HttpClient(httpClientHandler);
                            System.Net.Http.HttpRequestMessage request = new System.Net.Http.HttpRequestMessage(HttpMethod.Post, new Uri(url));
                            request.Headers.Range = new RangeHeaderValue(0, null);
                            HttpResponseMessage response = await client.SendAsync(request);
