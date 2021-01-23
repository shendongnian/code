    static void Main(string[] args)
    {
         using (var client = new HttpClient(new HttpClientHandler { AllowAutoRedirect = true}))
         {
             client.Timeout = TimeSpan.FromSeconds(20);
             using (var response = client.GetAsync("http://www.geenstijl.nl").Result)
             {
                 Console.WriteLine(response.IsSecure());
             }
             using (var response = client.GetAsync("http://www.facebook.com").Result)
             {
                 Console.WriteLine(response.IsSecure());
             }
         }
         Console.ReadLine();
    }
