    private async void Form1_Load(object sender, EventArgs e)
    {
        Task<int> file1 = test();
        Task<int> file2 = test();
        Task<int> file3 = test();
        int output1 = await file1;
        int output2 = await file2;
        int output3 = await file3;
    }
    static Random r = new Random();
    Task<int> test()
    {
        return Task.Run(() =>
        {
            var content = new StringBuilder();
            for (int i = 0; i < 100000; i++)
            {
                content.Append(i);
            }
            int n;
            lock (r) n = r.Next(1, 5000);
            System.IO.File.WriteAllText(string.Format(@"c:\test\{0}.txt", n), content.ToString());
            return 1;
        });
    }
