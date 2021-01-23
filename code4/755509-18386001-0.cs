    public static void ConnectToPUServer()
    {
        var client = new WebClient();
        while (i < 500 && networkIsAvailable)
        {
            string html = client.DownloadString(URI);
            //some data processing
            Console.WriteLine(i);
            i++;
            URI = "http://xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx/" + i + "/";
        }
        Console.WriteLine("Complete.");
        writer.Close();
    }
    
    static void NetworkChange_NetworkAvailabilityChanged(object sender, NetworkAvailabilityEventArgs e)
    {
        networkIsAvailable = e.IsAvailable;
        if (!networkIsAvailable)
        {
            Console.WriteLine("Internet connection not available! We resume as soon as network is available...");
        }
        else
        {
            ConnectToPUServer();
        }
    }
