    [ChildActionOnly]
    public ActionResult UserGeo()
    {
      return AsyncContext.Run(async () =>
      {
        var ip = RequestHelper.GetClientIpAddress(Request);
        var geoHelper = new GeoHelper(ip);
        var response = geoHelper.GetGeoAsync();
        var result = await response;
        var resultobj = JsonConvert.DeserializeObject<GeoInfo>(result);
        return Content(resultobj.city);
      }
    }
