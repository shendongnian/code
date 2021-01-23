    private async void buttonStringGet_Click_1(object sender, RoutedEventArgs e)
    {
        JsonWebAsync.JsonWebClient client = new JsonWebAsync.JsonWebClient();
        string result;
        try
        {
            var resp = await client.DoRequestAsync("myurl");
            result = resp.ReadToEnd();
        }
        catch (WebException ex)
        {
             // generic error handling
             result = string.Format("Could not get data. {0}", ex);
        }
        resultText.Text = result;
    }
