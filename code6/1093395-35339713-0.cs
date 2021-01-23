    //uppercase fail cakes
    [HttpGet]
    [Route("countries")]
    public async Task<GeoData> GeoData()
    {
        return await geoService.GetGeoData();
    }
    //lowercase nomnomnom cakes
    [HttpGet]
    [Route("geodata")]
    public async Task<GeoData> GeoData()
    {
        return await geoService.GetGeoData();
    }
