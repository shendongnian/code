    //using System.Web and Add a Reference to System.Web
    Dictionary<string, string> postParams = new Dictionary<string, string>();
    string[] rawParams = rawData.Split('&');
    foreach (string param in rawParams)
    {
        string[] kvPair = param.Split('=');
        string key = kvPair[0];
        string value = HttpUtility.UrlDecode(kvPair[1]);
        postParams.Add(key, value);
    }
    //Usage
    Console.WriteLine("Hello " + postParams["username"]);
