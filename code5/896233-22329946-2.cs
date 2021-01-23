    async Task<IEnumerable<string>> SomeMethod(...)
    {
        using (var client = new HttpClient())
        {
            var ss = await Task.WhenAll(services.Select(async x =>
            {
                var s = await client.GetStringAsync(x.Url);
                Console.WriteLine(response);
                return s;
            };
            Console.WriteLine("All tasks completed");
            return ss;
        }
    }
