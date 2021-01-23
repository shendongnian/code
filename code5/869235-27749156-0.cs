    public Task<int> ExampleMethodAsync()
    {
        var httpClient = new HttpClient();
    
        var task = httpClient.GetStringAsync("http://msdn.microsoft.com")
            .ContinueWith(previousTask =>
            {
                ResultsTextBox.Text += "Preparing to finish ExampleMethodAsync.\n";
    
                int exampleInt = previousTask.Result.Length;
    
                return exampleInt;
            });
    
        return task;
    }
