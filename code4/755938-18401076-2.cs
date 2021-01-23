    private async static void StraightHttpClient(int iterations, int amount)
    {
        var client = new HttpClient {BaseAddress = new Uri("http://localhost.:7474/db/data/")};
          
        for (int j = 0; j < iterations; j++)
        {
            DateTime start = DateTime.Now;
            for (int i = 0; i < amount; i++)
            {
                var response = await client.SendAsync(new HttpRequestMessage(HttpMethod.Post, "cypher/") { Content = new StringContent("{\"query\":\"create me\"}", Encoding.UTF8, "application/json") });
                if(response.StatusCode != HttpStatusCode.OK)
                    Console.WriteLine("Not ok");
            }
            TimeSpan timeTaken = DateTime.Now - start;
            Console.WriteLine("took {0}ms", timeTaken.TotalMilliseconds);
        }
    }
