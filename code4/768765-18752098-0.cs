    string[] keywords = System.IO.File.ReadAllLines(@"C:\Temp\keywords.txt");
    List<string> nomatch = new List<string>();
            
    System.Net.WebClient wc = new System.Net.WebClient();
    foreach (string word in keywords)
    {
        string response = wc.DownloadString("http://www.website.com/search.php?word=" + word);
        if (response != null && response.Contains("No matches found"))
            nomatch.Add(word);
    }
    if (nomatch.Count > 0)
        System.IO.File.WriteAllLines(@"C:\Temp\nomatch.txt", nomatch.ToArray());
