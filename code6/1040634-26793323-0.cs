        private static void CancelTask()
        {
            CancellationTokenSource cts = new CancellationTokenSource(750);
            Task.Run(() =>
            {
                int count = 0;
                while (true)
                {
                    Thread.Sleep(250);
                    Console.WriteLine(count++);
                    if (cts.Token.IsCancellationRequested)
                    {
                        break;
                    }
                }
            }, cts.Token).Wait();
        }
