    internal async Task<int> test()
    {
        return await Task.Run(() =>
        {
            string content = "";
            for (int i = 0; i < 10000; i++)
            {
                content += i.ToString();
            }
            System.IO.File.WriteAllText(string.Format(@"c:\test\{0}.txt",MyRandom.Next(1,5000)), content);
            return 1;
        });
    }
