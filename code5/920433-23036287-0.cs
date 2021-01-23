    private async Task<string> GetGreetingAsync()
    {
        return await Task.Run(() => "Hello").ConfigureAwait(false);
    }
    private void button1_Click(object sender, EventArgs e)
    {
        var x = GetGreetingAsync().Result;
    }
