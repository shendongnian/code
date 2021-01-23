    private async void button1_Click(object sender, EventArgs e)
        {
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            var result = await RemoteFileExists("http://www.google.com/");
            if (result)
            {
                // OK
                MessageBox.Show("OK");
            }
            else
            {
                //FAIL
                MessageBox.Show("Fail");
            }
        }
        private async Task<bool> RemoteFileExists(string url)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = "HEAD";
                HttpWebResponse response = await request.GetResponseAsync() as HttpWebResponse;
                return (response.StatusCode == HttpStatusCode.OK);
            }
            catch
            {
                return false;
            }
        }
