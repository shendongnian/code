    [ChildActionOnly]
    public async Task<ActionResult> UserGeo()
    {
        var ip = RequestHelper.GetClientIpAddress(Request);
        var geoHelper = new GeoHelper(ip);
        var result = await geoHelper.GetGeoAsync();
        var resultobj = JsonConvert.DeserializeObject<GeoInfo>(result);
        return Content(resultobj.city);
    }
