    private string getHtml(string url)
    {
        if(String.IsNullOrWhiteSpace(url)) { return; }
        // Create Web Request
        HttpWebRequest myWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
        // Set GET method
        myWebRequest.Method = "GET";
        // Get a response
        HttpWebResponse myWebResponse = (HttpWebResponse)myWebRequest.GetResponse();
        // Open a Stream to read the response
        StreamReader myWebSource = new StreamReader(myWebResponse.GetResponseStream());
        // Create a string to store the response
        string myPageSource = string.Empty;
        myPageSource= myWebSource.ReadToEnd();
        // Close the stream
        myWebResponse.Close();
        // Return the string
        return myPageSource;
    }
