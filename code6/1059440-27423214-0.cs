    using (WebClient webClient = new WebClient())
    {       
         var response = webClient.DownloadData(url);
         return Encoding.UTF8.GetString(response);
    }
