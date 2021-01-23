    private async void buttonRequest_Click(object sender, EventArgs e)
    {
        while (true)
        {
            using (var client = new WebClient())
            {
                Uri uri = new Uri("http://localhost:8181/");
                var response = await client.DownloadStringTaskAsync(uri);
                richTextResponse.Text += response + Environment.NewLine;
            }
            await Task.Delay(2000);
        }
    }
