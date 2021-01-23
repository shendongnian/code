      var query = Services.ContentManager.Query<CacheSettingsPart>();
      var cacheSettingsParts = query.Slice(1);
      if(cacheSettingsParts.Any())
      {
         _signals.Trigger(CacheSettingsPart.CacheKey);
         cacheSettingsParts.First().IgnoredUrls = "/dans-test";
      }
