    using (var client = new HttpClient())
    using (var response = await client.SendAsync(request))
    {
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadAsStreamAsync();
            // You can do whatever you want with the resulting stream, or you can ReadAsStringAsync, or just remove "Async" to use the blocking methods.
        }
        else
        {
            var statusCode = response.StatusCode;
            // You can do some stuff with the status code to decide what to do.
        }
    }
