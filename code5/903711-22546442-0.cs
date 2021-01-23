    public async Task<ActionResult> SelectFacility(
        int franchiseId, Guid? coachLoggingTimeStampId)
    {
        //...
        string responseFromServer = await Helpers.GetLocationByIPAddressAsync(
            userIpAddress);
        //...
    }
    public static async Task<string> GetLocationByIPAddress(string ipAddress)
    {
        using (var httpClient = new HttpClient())
            return await httpClient.GetStringAsync(
                GeoLocationPath.FreeGeoIP + ipAddress);
    }
     
