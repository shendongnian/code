    var httpRequestMessage = new HttpRequestMessage();
    
    httpRequestMessage.Method = httpMethod;
    httpRequestMessage.RequestUri = new Uri(url);
    httpRequestMessage.Headers.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue(_applicationAssembly.Name, _applicationAssembly.Version.ToString()));
    HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");
    switch (httpMethod.Method)
	{
		case "POST":
			httpRequestMessage.Content = httpContent;
			break;
	}
    var result = await httpClient.SendAsync(httpRequestMessage);
    result.EnsureSuccessStatusCode();
