    private async void button1_Click(object sender, EventArgs e)
    {
        using (var abc = new HttpClient())
        {
            var uri = new Uri(@"http://www.ifconfig.me/ip");
            txtMyIp.Text = await abc.GetStringAsync(uri);
        }
    }
