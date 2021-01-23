      switch (outputCacheLocation)
      {
        case OutputCacheLocation.Any:
          cacheability = HttpCacheability.Public;
          break;
        case OutputCacheLocation.Client:
          cacheability = HttpCacheability.Private;
          break;
        case OutputCacheLocation.Downstream:
          cacheability = HttpCacheability.Public;
          cache.SetNoServerCaching();
          break;
        case OutputCacheLocation.Server:
          cacheability = HttpCacheability.Server;
          break;
        case OutputCacheLocation.None:
          cacheability = HttpCacheability.NoCache;
          break;
        case OutputCacheLocation.ServerAndClient:
          cacheability = HttpCacheability.ServerAndPrivate;
          break;
        default:
          throw new ArgumentOutOfRangeException("cacheSettings", System.Web.SR.GetString("Invalid_cache_settings_location"));
      }
