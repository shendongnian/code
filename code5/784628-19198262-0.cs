    static void Main(string[] args)
    {
        var dgurl = "DGURL", user="DGUSER", pass="DGPASS";
        var url = string.Format("http://localhost/test.php?DGURL={0}&DGUSER={1}&DGPASS=DGPASS", dgurl, user, pass);
        using(var webClient = new WebClient()) 
        {
            var response = webClient.DownloadString(url);
            Console.WriteLine(response);
        }
    }
