    public Task<string> Method1()
    {
        return Task.Run(() => "blah");
    }
    private async void btn_Click(object sender, EventArgs e)
    {
        Label1.Text = await Method1();
    }
