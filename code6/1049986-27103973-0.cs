    public class JsonEncrypterHandler : DelegatingHandler
    {
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);
            var returnedJson = await response.Content.ReadAsStringAsync();
            dynamic dynamicJson = JsonConvert.DeserializeObject<dynamic>(returnedJson);
            foreach (var data in dynamicJson.Data)
            {
                if (data.objId != null)
                {
                    data.objId = Utils.Encrypt(data.objId);
                }
                if (data.policyId != null)
                {
                    data.policyId = Utils.Encrypt(data.policyId);
                }
            }
            response.Content = JsonConvert.SerializeObject(dynamicJson);
            return response;
        }
    }
