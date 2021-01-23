    private Task<string> GetGreetingAsync()
    {
        return Task.Run(() => "Hello");
    }
    async private void button1_Click(object sender, EventArgs e)
    {
        var x = await GetGreetingAsync();
    }
