    private static void LongRunning(CancellationToken cancelToken)
    {
        while (true)
        {
            if(cancelToken.IsCancellationRequested)
            {
                return;
            }
            //Not canceled, continue to work
        }
    }
