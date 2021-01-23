Install-Package Microsoft.AspNet.WebApi.Client
Program.cs
    internal class Program
    {
    	private static void Main(string[] args)
    	{
    		var request = new HttpRequestMessage();
    		request.Headers.Add("X-Token", "token");
    		request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    		request.Method = HttpMethod.Post;
    		var baseAddress = "http://localhost:12345/";
    		request.RequestUri = new Uri(baseAddress + "api/User");
    		var userDto = new UserDTO() {Username = "Alex"};
    		request.Content = new ObjectContent<UserDTO>(userDto, new JsonMediaTypeFormatter());
    		var httpClient = new HttpClient();
    		var response = httpClient.SendAsync(request).Result;
    		if (response.IsSuccessStatusCode)
    		{
    			// handle result code
    			Console.WriteLine(response.StatusCode);
    			Console.ReadLine();
    		}
    	}
    }
