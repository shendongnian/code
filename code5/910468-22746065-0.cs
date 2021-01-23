    class Program
    {
        static void Main(string[] args)
        {
            using (var webClient = new WebClient())
            {
                 webClient.DownloadStringCompleted+=webClient_DownloadStringCompleted;
                 webClient.DownloadStringAsync(new Uri("http://mp3skull.com/mp3/eminem.html"));          
            }
            System.Diagnostics.Process.GetCurrentProcess().WaitForExit();
        }
        static void webClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                Console.WriteLine("Error: {0}", e.Error.Message);
                return;
            }
            
            var source = e.Result.Trim();
            if (string.IsNullOrEmpty(source))
            {
                Console.WriteLine("Page not returned.");
                return;
            }
            foreach (Match match in Regex.Matches(source,"<div style=\"font-size:15px;\"><b>(?<title>.*?)</b></div>"))
            {
                Console.WriteLine(match.Groups["title"].Value);
            }
        }
    }
