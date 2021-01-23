    var client = new WebClient();
    var source = client.DownloadString("http://pastebin.com/raw.php?i=LAUx2zxn");
    var data = new List<string>(source.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries));
    if (data.ConvertAll(d => d.ToLower()).Contains(string.Concat("user", ":", "pass")))
    {
         // Successfully logged in.
    }
    else
    {
         // Invalid credentials
    }
