    // Get the CampaignService.
    AdGroupAdService adService = (AdGroupAdService)user
           .GetService(Google.Api.Ads.AdWords
           .Lib.AdWordsService.v201406.AdGroupAdService);
    List<AdGroupAdOperation> operations = new List<AdGroupAdOperation>();
    AdGroupAd targetAd = new AdGroupAd
    {
        adGroupId = ad.GroupId,
        ad = new Ad { id = ad.Id },
        tatus = ad.IsActive ? AdGroupAdStatus.ENABLED: AdGroupAdStatus.PAUSED
    };
    AdGroupAdOperation co = new AdGroupAdOperation
    {
        @operator = Operator.SET,
        operand = targetAd
    };
    operations.Add(ad);
    adService.mutate(operations.ToArray());
