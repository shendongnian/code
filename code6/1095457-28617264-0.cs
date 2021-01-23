            string loading = "LOADING...";
            var loadingTask = Task.Run(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    foreach (var letter in loading)
                    {
                        Console.Write("{0}", letter);
                        Thread.Sleep(250);
                    }
                    Console.Clear();
                    Console.Write("\r");
                }
            });
            var pocTask = Task.Run(() =>
            {
                for (int k = 0; k <= 100; k++)
                {
                    Console.Write("\r{0}%", k);
                    Thread.Sleep(150);
                }
            });
            Task.WaitAll(loadingTask, pocTask);
