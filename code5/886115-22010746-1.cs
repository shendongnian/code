    var query = from AdsProperties in db.utblCLFAdsPropertiesMasters
                        select new
                        {
                            AdsProperties.AdsProID,
                            AdsProperties.Name,
                            AdsProperties.IsActive,
                            ControlType = AdsProperties.ControlType < controls.Length ? controls[AdsProperties.ControlType-1] : null
                        };
            dt = query.CopyToDataTableExt();
