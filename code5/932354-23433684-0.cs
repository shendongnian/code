    private static void RaiseOnTimeout(Socket sock, long timeoutMicroSeconds)
    {
        List<socket> sockList = new List<Socket>() {sock};
        int numEvents = Context.Poller(sockList), timeoutMicroSeconds);
        if (numEvents == 0)
        {
            throw new TimeoutException();
        }
    }
