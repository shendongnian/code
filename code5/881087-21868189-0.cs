    public Task<String> FileToBase64(String filePath)
    {
        TaskCompletionSource<string> completion = new TaskCompletionSource<string>();
        String convertedFile = "";
        WebClient client = new WebClient();
        client.OpenReadCompleted += (s, e) =>
        {
            TextReader reader = new StreamReader(e.Result);
            string result = reader.ReadToEnd();
            completion.SetResult(result);
        };
        client.OpenReadAsync(new Uri(filePath));
        return completion.Task;
    }
