            Console.WriteLine("\nStreamed Content: \n");
            int count = 0;
            (from strm in twitterCtx.UserStream
             where strm.Type == UserStreamType.Site &&
                   strm.Follow == "15411837,16761255"
             select strm)
            .StreamingCallback(strm =>
            {
                Console.WriteLine(strm.Content + "\n");
                if (count++ >= 10)
                {
                    strm.CloseStream();
                }
            })
            .SingleOrDefault();
