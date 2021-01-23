    static void SearchStackOverflow(string y)
    {
        var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://api.stackoverflow.com/1.1/search?intitle=" + Uri.EscapeDataString(y));
        httpWebRequest.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
        httpWebRequest.Method = "GET";
        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        string responseText;
        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        {
            responseText = streamReader.ReadToEnd();
        }
        var result = (SearchResult)new JavaScriptSerializer().Deserialize(responseText, typeof(SearchResult));
        .... do something with result ...
     }
     class SearchResult
     {
          public List<Question> questions { get; set; }
     }
     class Question
     {
          public string title { get; set; }
          public int answer_count { get; set; }
     }
