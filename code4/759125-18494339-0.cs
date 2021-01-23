    GetInformation R = new GetInformation();
    Console.WriteLine("Please enter a valid url protocol://domain");
    var input = R.InputString();
    var uri = new Uri(input);
    var client = new System.Net.WebClient();
    var downloadedString = client.DownloadString(uri);
    Console.WriteLine("String: {0}", downloadedString);
