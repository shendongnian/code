    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    
    namespace HttpClientMemoryLeak
    {
        using System.Net;
        using System.Threading;
    
        class Program
        {
            static HttpClientHandler handler = new HttpClientHandler();
    
            private static HttpClient client = new HttpClient(handler);
    
            public static async Task TestMethod()
            {
                try
                {
                    using (var response = await client.PutAsync("http://localhost/any/url", null))
                    {
                    }
                }
                catch
                {
                }
            }
    
            static void Main(string[] args)
            {
                for (int i = 0; i < 1000000; i++)
                {
                    Thread.Sleep(10);
                    TestMethod();
                }
    
                Console.WriteLine("Finished!");
                Console.ReadKey();
            }
        }
    }
