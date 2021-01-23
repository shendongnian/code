    private void LoopUndisposedStream()
    {
        for(int i = 0; i < 100000; i++)
        {
           CreateUndisposedStream();
        }
    }
    private void CreateUndisposedStream()
    {
        WebRequest request = WebRequest.Create("http://www.microsoft.com");
        WebResponse response = request.GetResponse();
        StreamReader responseStream = new StreamReader(response.GetResponseStream());
        string responseText = responseStream.ReadToEnd();
        Console.WriteLine(responseText); // Displays the HTML of the website
    }
    
