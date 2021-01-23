    using (HttpClientHandler hHandler = new HttpClientHandler())
    {
        HttpResponseMessage response = await hClient.GetAsync(URL);
        System.IO.Stream oStrm = await response.Content.ReadAsStreamAsync();
        XmlSerializer oSer = new XmlSerializer(typeof(T));
        return (T)oSer.Deserialize(oStrm);
    }
