    static void Main(string[] args)
    {
        Write("0.bin");
        Write("1.bin");
        Write("2.bin");
        ReadAllFile("2.bin"); // warmup
        var sw = new Stopwatch();
        sw.Start();
        ReadAllFile("0.bin");
        ReadAllFile("1.bin");
        ReadAllFile("2.bin");
        sw.Stop();
        Console.WriteLine("Sync: " + sw.Elapsed);
        ReadAllFileAsync("2.bin").Wait(); // warmup
        sw.Restart();
        ReadAllFileAsync("0.bin").Wait();
        ReadAllFileAsync("1.bin").Wait();
        ReadAllFileAsync("2.bin").Wait();
        sw.Stop();
        Console.WriteLine("Async: " + sw.Elapsed);
        Console.ReadKey();
    }
    static void ReadAllFile(string filename)
    {
        using (var file = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, false))
        {
            byte[] buff = new byte[file.Length];
            file.Read(buff, 0, (int)file.Length);
        }
    }
    static async Task ReadAllFileAsync(string filename)
    {
        using (var file = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, true))
        {
            byte[] buff = new byte[file.Length];
            await file.ReadAsync(buff, 0, (int)file.Length);
        }
    }
    static void Write(string filename)
    {
        int size = 1024 * 1024 * 256;
        var data = new byte[size];
        var random = new Random();
        random.NextBytes(data);
        File.WriteAllBytes(filename, data);
    }
