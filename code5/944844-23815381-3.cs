        private void button1_Click(object sender, EventArgs e)
        {
            using (var abc = new WebClient())
            {
                var uri = new Uri(@"http://www.ifconfig.me/ip");
                abc.DownloadStringCompleted += (o, args) => txtMyIp.Text = args.Result;
                abc.DownloadStringAsync(uri);
            }
        }
