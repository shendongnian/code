    public async System.Threading.Tasks.Task<bool> AuthenticateAsync()
    {
        byte[] dataStream = System.Text.Encoding.UTF8.GetBytes("...");
        System.Net.WebRequest webRequest = System.Net.WebRequest.Create("...");
        webRequest.Method = "POST";
        webRequest.ContentType = "application/json";
        webRequest.ContentLength = dataStream.Length;
        Stream newStream = await webRequest.GetRequestStreamAsync();
        // Send the data.
        newStream.Write(dataStream, 0, dataStream.Length);
        newStream.Close();
        var webResponse = await webRequest.GetResponseAsync();
        return true;
    }
