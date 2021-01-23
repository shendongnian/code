    private async void button1_Click(object sender, EventArgs e)
    {
        var response = await SendAsync();
        Debug.WriteLine(response); 
    }
    async Task<Response> SendAsync()
    {
        await SendRequestAsync(new Request());
        var response = await RecieveResponseAsync();
        return response;
    }
    async Task SendRequestAsync(Request request)
    {
        await Task.Delay(1000); // actual I/O operation
    }
    async Task<Response> RecieveResponseAsync()
    {
        await Task.Delay(1000); // actual I/O operation
        return null;
    }
