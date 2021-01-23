    public static void Syncmethod()
        {
            var sw = new Stopwatch();
            sw.Start();
            var client = new HttpClient();
            var tasks = Enumerable.Range(0, 800).Select(x => Task.Run(() =>
            {
                var swx = new Stopwatch();
                swx.Start();
                var result =
                client.GetStringAsync("http://yandex.ru").ContinueWith(task =>
                {
                    try
                    {
                        swx.Stop();
                        Console.WriteLine(x + " " + task.Result + " in " + swx.ElapsedMilliseconds + " ms.");
                        return task.Result;
                    }
                    catch (Exception e)
                    {
                        swx.Stop();
                        Console.WriteLine(x + " Exception: " + e.Message);
                        throw e;
                    }
                }, TaskContinuationOptions.AttachedToParent);
            })).ToArray();
            foreach (var task in tasks)
                task.Wait(60000);
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
        }
