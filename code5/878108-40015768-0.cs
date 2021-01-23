    private static async void Main()
    {
        var client = new RestClient();
        var request = new RestRequest("http://www.google.com");
        Task<IRestResponse> t = client.ExecuteTaskAsync(request);
        t.Wait();
        var restResponse = await t;
        Console.WriteLine(restResponse.Content); // Will output the HTML contents of the requested page
    }
