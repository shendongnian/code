    var query = from AdsProperties in db.utblCLFAdsPropertiesMasters
                        select new
                        {
                            AdsProperties.AdsProID,
                            AdsProperties.Name,
                            AdsProperties.IsActive,
                            ControlType = controls[AdsProperties.ControlType-1]
                        };
            dt = query.CopyToDataTableExt();
