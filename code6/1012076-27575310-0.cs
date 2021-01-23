    // This example uses http://httpbin.org/user-agent, 
    // which just echoes back the user agent from the request.
	var httpClient = new HttpClient
	{
		BaseAddress = new Uri("http://httpbin.org"), 
		DefaultRequestHeaders = {{"User-Agent", "Refit"}}
	};
	var service = RestService.For<IUserAgentExample>(httpClient);
	var result = await service.GetUserAgent(); // result["user-agent"] == "Refit"
    // Assuming this interface
    public interface IUserAgentExample
	{
		[Get("/user-agent")]
		Task<Dictionary<string, string>> GetUserAgent();
	}
	
