    class Program
    {
      static void Main(string[] args)
      {
        start().Wait();
      }
    
      private async static void start()
      {
        Fixture fixture = new Fixture();
        HttpClient client = new HttpClient();
    
        dynamic listOfCustomers = JToken.Parse(await client.GetStringAsync("http://localhost:12345/api/WebCustomers").ConfigureAwait(false));
         // Rest Of Code..
      }
