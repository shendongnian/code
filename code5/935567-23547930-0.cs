    // Convert string into System.Net.Http.HttpContent using UTF-8 encoding.
    StringContent stringContent = new StringContent(
        "blah blah",
        System.Text.Encoding.UTF8);
    HttpResponseMessage reponse = await client.PostAsync(uri, stringContent);
