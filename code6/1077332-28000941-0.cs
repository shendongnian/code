        private async void button1_Click(object sender, EventArgs e)
        {
            this.Text = "doing something...";
            var result = await SomeHeavyWork();
            this.Text = result.ToString();
        }
        private async Task<int> SomeHeavyWork()
        {
            using (var hc = new HttpClient())
            {
                var data = await hc.GetAsync("www.google.com");
                return data.Content.Headers.Count();
            }
        }
