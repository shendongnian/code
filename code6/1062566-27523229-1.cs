    private static void PingCompleted(object sender, PingCompletedEventArgs e)
    {
        string ip = (string)e.UserState;
        if (e.Reply != null && e.Reply.Status == IPStatus.Success)
        {
            // Logic for Ping Reply Success
            Console.WriteLine(String.Format("Host: {0} ping successful", ip));
        }
        else
        {
            // Logic for Ping Reply other than Success
        }
    }
