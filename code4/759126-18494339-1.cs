    GetInformation R = new GetInformation();
    Console.WriteLine("Please enter a valid url protocol://domain");
    var input = R.InputString();
    Uri uri;
    if(!Uri.TryCreate(input, UriKind.Absolute, out uri))
    {
        Console.WriteLine("Url format could not be determined for {0}", input);
        Environment.Exit(1);
    }
    var client = new System.Net.WebClient();
    var downloadedString = client.DownloadString(uri);
    Console.WriteLine("String: {0}", downloadedString);
