    public async void CreateIndex() {
                using (var httpClient = new HttpClient()) {
                    using (var request = new HttpRequestMessage(HttpMethod.Put, new Uri("http://elastic_server_ip/your_index_name"))) {
                        var content = @"{ ""settings"" : { ""number_of_shards"" : 1 } }";
                        request.Content = new StringContent(content);
                        var response = await httpClient.SendAsync(request);
                    }
                }
            }
