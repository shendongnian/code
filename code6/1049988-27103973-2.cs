	public class JsonEncrypterHandler : DelegatingHandler
    {
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);
            var returnedJson = await response.Content.ReadAsStringAsync();
			
			JObject jObj = JObject.Parse(returnedJson);
			
			List<JToken> objIdTokens = new List<JToken>();
			List<JToken> policyIdTokens = new List<JToken>();
			
			FindTokens(jObj, "objid", objIdTokens);
			FindTokens(jObj, "policyid", policyIdTokens);
			
			foreach (JValue objId in objIdTokens)
			{
				objId.Value = Utils.Encrypt(objIdValue);
			}
			
			foreach (JValue policyId in policyIdTokens)
			{
				policyId.Value = Utils.Encrypt(policyIdTokens);
			}
			
            response.Content = JsonConvert.SerializeObject(jObj);
            return response;
        }
    }
