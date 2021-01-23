    var statusTweets = (from strm in twitterContext.Streaming
                        where strm.Type == StreamingType.User
                        && strm.ScreenName == "Bloomberg"
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
                        });
