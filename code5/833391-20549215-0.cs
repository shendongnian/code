    const int MaxNumberOfCycles = 10;
    
    static void Main()
    {
        Start().Wait();
    }
    
    async Task Start()
    {
        var client = new Client();
        var cycle = 0;
        
        while (cycle < MaxNumberOfCycles)
        {
            var response = await client.SearchAsync(cycle++);
        }
    }
    
    class Client
    {
        public async Task<HttpResponseMessage> SearchAsync(int n)
        {
            // parameter 'n' used to vary web service response data
            var url = ... // url removed for privacy
            using (var client = new HttpClient())
            using (var response = await client.GetAsync(url))
            {
                return response;
            }
        }
    }
