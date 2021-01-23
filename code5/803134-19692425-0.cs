        CancellationTokenSource cts = new CancellationTokenSource();
        ParallelOptions options = new ParallelOptions
        {
            CancellationToken = cts.Token
        };
        Parallel.ForEach(data, options, i =>
        {
            try
            {
                if (cts.IsCancellationRequested) return;
                //do stuff
            }
            catch (Exception ex)
            {
                cts.Cancel(false);
            }
        });  
