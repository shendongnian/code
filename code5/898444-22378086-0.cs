            var list = new List<Task>();
            for (var i = 0; i < 10; ++i)
            {
                var i2 = i;
                var t = new Task(() =>
                    {
                        Thread.Sleep(100);
                        Console.WriteLine(i2);
                    });
                list.Add(t);
                t.Start();
            }
            Task.WaitAll(list.ToArray());
