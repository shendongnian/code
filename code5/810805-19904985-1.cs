    private async void buttonStringGet_Click_1(object sender, RoutedEventArgs e)
    {
        JsonWebAsync.JsonWebClient client = new JsonWebAsync.JsonWebClient();
        string requestUrl = ComputeRequestUrl(); // I assume this code exists somewhere.
        System.Diagnostics.Debug.WriteLine("Sending request for {0}", requestUrl);
        var resp = await client.DoRequestAsync(requestUrl);
        string result = resp.ReadToEnd();
        resultText.Text = result;
    }
