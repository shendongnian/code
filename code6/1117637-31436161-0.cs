    using (var client = new HttpClient())
            {
                var httpRequest = new HttpRequestMessage(new HttpMethod("POST"), _uri);
                //client.BaseAddress = new Uri(_uri);
                try
                {
                    client.Timeout = TimeSpan.FromSeconds(30);
                    var _cancelTokenSource = new CancellationTokenSource();
                    var _cancelToken = _cancelTokenSource.Token;
                    var response = await client.SendAsync(httpRequest, _cancelToken).ConfigureAwait(false);
                    resp = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                }
                catch (Exception e)
                {
                    Debug.WriteLine("HTTP ERROR: " + e.Message);
                    throw e;
                }
            }
