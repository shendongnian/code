    var query = from AdsProperties in db.utblCLFAdsPropertiesMasters
        select new
        {
            AdsProperties.AdsProID,
            AdsProperties.Name,
            AdsProperties.IsActive,
            ControlType = GetControlType(AdsProperties.ControlType)
        };
    dt = query.CopyToDataTableExt();
