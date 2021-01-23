        static async Task DoRxObservableStreamAsync(TwitterContext twitterCtx)
        {
            Console.WriteLine("\nStreamed Content: \n");
            int count = 0;
            var cancelTokenSrc = new CancellationTokenSource();
            try
            {
                var observable =
                    await
                        (from strm in twitterCtx.Streaming
                                                .WithCancellation(cancelTokenSrc.Token)
                         where strm.Type == StreamingType.Filter &&
                               strm.Track == "twitter"
                         select strm)
                        .ToObservableAsync();
                observable.Subscribe(
                    strm =>
                    {
                        HandleStreamResponse(strm);
                        if (count++ >= 5)
                            cancelTokenSrc.Cancel();
                    },
                    ex => Console.WriteLine(ex.ToString()),
                    () => Console.WriteLine("Completed"));
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Stream cancelled.");
            }
        }
