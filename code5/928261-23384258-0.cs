    static public void DownloadResults(IAsyncResult ar)
    {
        // Get the message from the service bus.
        msg = client.EndReceive(ar);
        if (msg == null)
        {
            // Start waiting for the message again.
            client.BeginReceive(new TimeSpan(6, 0, 0), new AsyncCallback(DownloadResults), null);
            return;
        }
    }
