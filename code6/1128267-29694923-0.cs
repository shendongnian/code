    public async Task<string> GeneralRequestHandler(string RequestUrl, object ReqObj)
            {
                try
                {
                    string json = Newtonsoft.Json.JsonConvert.SerializeObject(ReqObj);
                    HttpContent content = new StringContent(json);
                    Windows.Web.Http.IHttpContent c = new Windows.Web.Http.HttpStringContent(json);
                    c.Headers.ContentType = new Windows.Web.Http.Headers.HttpMediaTypeHeaderValue("application/json");
                    Windows.Web.Http.Filters.HttpBaseProtocolFilter aHBPF = new Windows.Web.Http.Filters.HttpBaseProtocolFilter();
                  
                    aHBPF.IgnorableServerCertificateErrors.Add(Windows.Security.Cryptography.Certificates.ChainValidationResult.Untrusted);
                    aHBPF.IgnorableServerCertificateErrors.Add(Windows.Security.Cryptography.Certificates.ChainValidationResult.InvalidName);
                    string responseText;
                    using (var handler = new Windows.Web.Http.HttpClient(aHBPF))
                    {
                        Windows.Web.Http.HttpResponseMessage r = await handler.PostAsync(new Uri(RequestUrl), c);
                        responseText = await r.Content.ReadAsStringAsync();
                    }
                }
                catch (HttpRequestException ex)
                {
                  
                }
    			
    			return responseText;
            }
*
