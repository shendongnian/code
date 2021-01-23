    public async Task<string> Method1(string someString, int someInt)
    {
        return string.Format("{0}{1}", someString, someInt);
    }
    private async void btn_Click(object sender, EventArgs e)
    {
        Label1.Text = await Method1("EZ", 1);
    }
