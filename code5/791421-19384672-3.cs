    public async Task<int> DoSomethingAsync(string input)
    {
        // Do something with input asynchronously
        using (HttpClient client = new HttpClient())
        {
            await ... /* something to do with input */
        }
        int result = ...;
        return result;
    }
