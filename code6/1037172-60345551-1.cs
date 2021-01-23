    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    namespace GetNuGetVer
    {
        class VersionsResponse
        {
            public string[] Versions { get; set; }
        }
		
        class Program
        {
            static async Task Main(string[] args)
            {
                var packageName = "Enums.NET";
                var url = $"https://api.nuget.org/v3-flatcontainer/{packageName}/index.json";
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(url);
                var versionsResponse = await response.Content.ReadAsAsync<VersionsResponse>();
                var lastVersion = versionsResponse.Versions[^1]; //(length-1)
                // and so on ..
            }
        }
    }
