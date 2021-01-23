    public async Task<FormattedAdress> GetFormattedAddress(DBGeography Location)
    {
        using(var client = new HttpClient())
        {
            var URI = new URi......
            using(Stream respSream= await client.GetStreamAsync(URI))
            {
                FormatedAddress address =....
                return address; 
            }
        }
    }
