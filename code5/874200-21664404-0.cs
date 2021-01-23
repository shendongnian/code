    using System;
    using System.Text;
    using System.Net.Http;
    using System.Threading.Tasks;
    namespace RestAPICallTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                Run().Wait();
            }
            static async Task Run()
            {
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Add("X-PUSHBOTS-APPID", "52ee4bd11d0ab1282a8b458e");
                httpClient.DefaultRequestHeaders.Add("X-PUSHBOTS-SECRET", "b28825277373379b8c62126b16359d46");
                var postData = "{\"platform\":\"[1]\", \"msg\":\"Hi from Tali\" ,\"badge\":\"10\" ,\"sound\":\"default\"}";
                var content = new StringContent(postData, Encoding.UTF8, "application/json");
            
                var response = await httpClient.PostAsync("https://api.pushbots.com/push/all", content);
                response.EnsureSuccessStatusCode();
                var responseJson = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseJson);
            }
        }
    }
