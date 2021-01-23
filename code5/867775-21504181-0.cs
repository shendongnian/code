    AutodiscoverService ads = new AutodiscoverService(new Uri("..."));
    ads.EnableScpLookup = false;
    ads.Credentials = new NetworkCredential(...);
    ads.RedirectionUrlValidationCallback = delegate { return true; };
    GetUserSettingsResponse grResp = ads.GetUserSettings("someemail@domain.com", UserSettingName.ExternalEwsUrl);
    Uri casURI = new Uri(grResp.Settings[UserSettingName.ExternalEwsUrl].ToString());
    var service = new ExchangeService()
    {
        Url = casURI,
        Credentials = ads.Credentials,
    };
