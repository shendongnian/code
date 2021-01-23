        public void StreamFromUser()
        {
            var block = new AutoResetEvent(false);
            
            var service = GetAuthenticatedService();
            service.StreamUser((streamEvent, response) =>
            {
                if (streamEvent is TwitterUserStreamEnd)
                {
                    block.Set();
                }
                if (response.StatusCode == 0)
                {
                    if (streamEvent is TwitterUserStreamFriends)
                    {
                        var friends = (TwitterUserStreamFriends)streamEvent;
                    }
                    if (streamEvent is TwitterUserStreamEvent)
                    {
                        var @event = (TwitterUserStreamEvent)streamEvent;
                    }
                    if (streamEvent is TwitterUserStreamStatus)
                    {
                        var tweet = ((TwitterUserStreamStatus)streamEvent).Status;
                    }
                    if (streamEvent is TwitterUserStreamDirectMessage)
                    {
                        var dm = ((TwitterUserStreamDirectMessage)streamEvent).DirectMessage;
                    }
                    if (streamEvent is TwitterUserStreamDeleteStatus)
                    {
                        var deleted = (TwitterUserStreamDeleteStatus)streamEvent;
                    }
                    if (streamEvent is TwitterUserStreamDeleteDirectMessage)
                    {
                        var deleted = (TwitterUserStreamDeleteDirectMessage)streamEvent;
                    }
                }
                else
                {
                    Assert.Ignore("Stream responsed with status code: {0}", response.StatusCode);
                }
            });
            block.WaitOne();
            service.CancelStreaming();
        }
