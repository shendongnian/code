        static async Task MainAsync()
        {
            await Observable.Generate(new Random(), x => true,
                                      x => x, x => x.Next(250, 500))
                .Select((x, idx) => Observable.FromAsync(async ct =>
                {
                    Console.WriteLine("start:  " + idx.ToString());
                    await Task.Delay(x, ct);
                    Console.WriteLine("finish: " + idx.ToString());
                    return idx;
                }))
                .Concat()
                .Take(10)
                .LastOrDefaultAsync();
        }
