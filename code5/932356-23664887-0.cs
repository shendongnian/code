    public static void RaiseOnTimeout(Socket sock, TimeSpan timeout)
    {
        List<PollItem> pollItemsList = new List<PollItem>();
        PollItem pollItem = sock.CreatePollItem(IOMultiPlex.POLLIN);
        pollItemsList.Add(pollItem);
    
        int numReplies = Context.Poller(pollItemsList.ToArray(), timeout.Value.Ticks * 10);
    
        if (numReplies == 0)
        {
            throw new TimeoutException();
        }
    }
