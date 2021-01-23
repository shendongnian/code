    Console.WriteLine("\nStreamed Content: \n");
    int count = 0;
    await
        (from strm in twitterCtx.Streaming
         where strm.Type == StreamingType.User
         select strm)
        .StartAsync(async strm =>
        {
            string message = 
                string.IsNullOrEmpty(strm.Content) ? 
                    "Keep-Alive" : strm.Content;
            Console.WriteLine(
                (count + 1).ToString() + 
                ". " + DateTime.Now + 
                ": " + message + "\n");
            if (count++ == 5)
                strm.CloseStream();
        });
