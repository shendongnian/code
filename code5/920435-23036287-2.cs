    private async Task<string> GetGreetingAsync()
    {
        return await Task.Run(() => "Hello");
    }
    async private void button1_Click(object sender, EventArgs e)
    {
        var x = await GetGreetingAsync();
    }
