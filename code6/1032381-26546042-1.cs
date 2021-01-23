    using (var hc = new HttpClient())
    {
        hc.BaseAddress = new Uri(_orderServiceUrl);
        hc.DefaultRequestHeaders.Accept.Clear();
        hc.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        HttpResponseMessage response = hc.PostAsJsonAsync("", products).Result;
    }
