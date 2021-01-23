    void Main()
    {
        Observable.FromAsync(GetNextImageAsync)
                .Timeout(TimeSpan.FromSeconds(1), Observable.Empty<byte[]>())
                .Subscribe(Console.WriteLine);
    }
    
    public async Task<byte[]> GetNextImageAsync(CancellationToken ct)
    {
        using(var wc = new HttpClient())
        {
            var response = await wc.GetAsync(new Uri("http://www.google.com"),
                HttpCompletionOption.ResponseContentRead, ct);
            return await response.Content.ReadAsByteArrayAsync();
        }
    }
