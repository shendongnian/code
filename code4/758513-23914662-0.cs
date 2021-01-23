    using System.Net.Http.Headers; // For AuthenticationHeaderValue
    // ...
    try
    {
        const string uriSources = "https://api.del.icio.us/v1/tags/bundles/all?private={myKey}";
        using (var client = new HttpClient())
        {
            var byteArray = Encoding.ASCII.GetBytes("MyUSER:MyPASS");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            var result = await client.GetStringAsync(uriSources);
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message, "ERROR...", MessageBoxButton.OK);
    }
