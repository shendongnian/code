    static void Main()
    {
      MainAsync().Wait();
    }
    static async Task MainAsync()
    {
      await GetSomethingAsync();
      await Task.WhenAll(DoSomeWorkAsync(1), DoSomeWorkAsync(2));
    }
    static async Task GetSomethingAsync()
    {
      Console.WriteLine("Starting GetSomething");
      HttpClient client = new HttpClient();
      ...
      HttpResponseMessage response = await client.GetAsync("api/v1/somethings");
      somethingList = await response.Content.ReadAsAsync<SomeObject>();
      Console.WriteLine("Done with GetSomething");
    }
    static async Task DoSomeWorkAsync(int workNumber)
    {
      Console.Writeline("Start work#" + workNumber);
    }
