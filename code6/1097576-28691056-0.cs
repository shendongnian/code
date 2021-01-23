    private static void Main(string[] args)
    {
        Task.Run(() =>
        {
            int count = 0;
            while (count < 30)
            {
                int _;
                int iocpThreads;
                ThreadPool.GetAvailableThreads(out _, out iocpThreads);
                Console.WriteLine("Current number of IOCP threads availiable: {0}", iocpThreads);
                count++;
                Thread.Sleep(10);
            }
        });
        for (int i = 0; i < 30; i++)
        {
            GetUrl(@"http://www.ynet.co.il");
        }
        Console.ReadKey();
    }
    private static async Task<string> GetUrl(string url)
    {
        var httpClient = new HttpClient();
        var response = await httpClient.GetAsync(url);
        return await response.Content.ReadAsStringAsync();
    }
