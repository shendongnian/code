    public async Task ChattyWriter()
    {
        int count = 0;
        while (true)
        {
            var message = String.Format("Chatty Writer number {0}", count);
            Trace.WriteLine(message);
            count++;
            await Task.Delay(1000);
               ...
        }
    }
