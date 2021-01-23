     Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    bc.Add(i);
                    Thread.Sleep(100); // sleep 100 ms between adds
                    cts.ThrowIfCancellationRequested();
                }
                // Need to do this to keep foreach below from hanging
                bc.CompleteAdding();
            },cts.Token);
