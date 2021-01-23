    public async Task ConnectAsync()
    {
        await Client.ConnectAsync(Host, Port);
    }
    private void Form1_Load(object sender, EventArgs e)
    {
        try
        {
            Client client = new Client("localhost", 8080);
            await client.ConnectAsync();
        }
        catch (SocketException socketException)
        {
            MessageBox.Show(socketException.Message);
        }
    }
