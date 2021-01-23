    while (_queue.TryTake(out msg, TimeSpan.Infinite))
    {
        if (msg.Type == Email)
        {
            // start asynchronous task to send email
        }
        else
        {
            // write to log file
        }
    }
