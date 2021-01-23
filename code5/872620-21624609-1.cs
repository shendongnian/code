     private async void RefreshJSONButton_Click(object sender, RoutedEventArgs e)
        {
            this.JsonView.Text = string.Empty;
            HttpClient client = new HttpClient();
        int unixTimestamp = (int)(DateTime.Now.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        
        string url =
        "http://API1 Address Here/Your queries&temp=unixTimestamp";
        string x = await client.GetStringAsync(url);
        this.JsonView.Text = x;
        client.Dispose();
        }
