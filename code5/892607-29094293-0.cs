    public static async Task<bool> UploadFileAsync(string filepath, string container, string filename )
    {
        var httpClient = new HttpClient();
        var requestMessage = new HttpRequestMessage(HttpMethod.Post,
            @"https://identity.api.rackspacecloud.com/v2.0/tokens")
        {
            Content = new StringContent(
                @"{ 
                    ""auth"": { 
                        ""RAX-KSKEY:apiKeyCredentials"": { 
                        ""username"": ""username"",
                        ""apiKey"": ""apikey""
                    }
                }
        }")
        };
        requestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        
        var response = await httpClient.SendAsync(requestMessage);
        var responseContent = await response.Content.ReadAsStringAsync();
        var obj = JObject.Parse(responseContent);
        var tokenId = obj.SelectToken("access.token.id").ToObject<string>();
        var endpointPublicURL = obj.SelectToken("access.serviceCatalog[?(@.name == 'cloudFiles')].endpoints[0].publicURL");
        var fileBytes = File.ReadAllBytes(filepath);
        using (var httpContent = new ByteArrayContent(fileBytes))
        {
            httpContent.Headers.Add("X-Auth-Token", tokenId);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
            httpContent.Headers.ContentLength = fileBytes.LongLength;
            var result = await httpClient.PutAsync(endpointPublicURL + "/" + container + "/" filename, httpContent);
        }
        return true;
    }
