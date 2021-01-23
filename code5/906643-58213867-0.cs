    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using System.Net.Http.Formatting;
    
    namespace TestingRESTAPI
    {
        class Program
        {
            static void Main(string[] args)
            {
                RunAsync().Wait();
            }
    
            static async Task RunAsync()
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("<<provide your uri>>");
                    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("OAuth","xyz");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    
                    Console.WriteLine("Get");
                    HttpResponseMessage response = await client.GetAsync("<<provide your uri>>");
                    if(response.IsSuccessStatusCode)
                    {
                        Sites sites = await response.Content.ReadAsAsync<Sites>();
                        Console.WriteLine("Name: " + sites.name + "," + "Year: " + sites.yearInscribed);
                    }
                
                    Console.WriteLine("Post");
    
                    Sites newsite = new Sites();
                    newsite.name = "Ryan";
                    newsite.yearInscribed = "2019";
                    response = await client.PostAsJsonAsync("api/sites", newsite);
                    if(response.IsSuccessStatusCode)
                    {
                        Uri siteUrl = response.Headers.Location;
                        Console.WriteLine(siteUrl);
                    }
    
                }
            }
        }
    }
