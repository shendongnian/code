    var start = DateTime.Now;
    if (NetworkInterface.GetIsNetworkAvailable())
    {
        interfaces = NetworkInterface.GetAllNetworkInterfaces()[0];
    }
    var currentByteReceive = interfaces.GetIPv4Statistics().BytesReceived;
    Console.WriteLine("Timespan: {0}", DateTime.Now - start);
