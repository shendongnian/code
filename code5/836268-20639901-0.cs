    public async Task<bool> PostProperty()
    {
        try
        {          
            var reader = new StringReader(await Request.Content.ReadAsStringAsync());
            var serializer = new XmlSerializer(typeof(property));
            var instance = (property)serializer.Deserialize(reader);
        }
    }
