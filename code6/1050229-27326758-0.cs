    using System;
    using System.Net;
    using System.Net.Http;
    
    namespace Test
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Making API Call...");
                using (var client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate }))
                {
                    client.BaseAddress = new Uri("https://api.stackexchange.com/2.2/");
                    HttpResponseMessage response = client.GetAsync("answers?order=desc&sort=activity&site=stackoverflow").Result;
                    response.EnsureSuccessStatusCode();
                    string result = response.Content.ReadAsStringAsync().Result;
                    Console.WriteLine("Result: " + result);
                }
                Console.ReadLine();
            }
        }
    }
