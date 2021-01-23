    private static bool? _adsRemoved;
    private bool AdsRemoved
    {
        get
        {
            if (_adsRemoved == null)
            {
                _adsRemoved =  CurrentApp.LicenseInformation.ProductLicenses["RemoveAdsProductID"].IsActive;
            }
            return _adsRemoved.Value;
        }
        set 
        { 
            _adsRemoved =  CurrentApp.LicenseInformation.ProductLicenses["RemoveAdsProductID"].IsActive;
        }
    }
