    Geolocator geolocator = new Geolocator();
    
                try
                {
                    geoposition = await geolocator.GetGeopositionAsync(
                        maximumAge: TimeSpan.FromMinutes(5),
                        timeout: TimeSpan.FromSeconds(5));
                }
                catch (Exception ex)
                {
                    // Location not allowed by user phone setting
                    if (ex.HResult == -2147024891)
                    {
                        ... LocationNotAuthorized
                    }
    
                    ...
                }
