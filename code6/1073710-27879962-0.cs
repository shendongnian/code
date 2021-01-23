    using (var client = new HttpClient()) {
        var response = await client.GetStringAsync(new Uri("URL"));
        IPAddress ip;
        if (IPAddress.TryParse(response, out ip)) {
            //Success
        }
    }
