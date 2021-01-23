    <cachingConfiguration defaultCacheManager="MyCacheManager">
    <cacheManagers>
      <add name="MyCacheManager" type="Microsoft.Practices.EnterpriseLibrary.Caching.CacheManager, Microsoft.Practices.EnterpriseLibrary.Caching, Version=5.0.414.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
           expirationPollFrequencyInSeconds="60"
           maximumElementsInCacheBeforeScavenging="50000"
           numberToRemoveWhenScavenging="1000"
           backingStoreName="NullBackingStore" />
    </cacheManagers>
    <backingStores>
      <add type="Microsoft.Practices.EnterpriseLibrary.Caching.BackingStoreImplementations.NullBackingStore, Microsoft.Practices.EnterpriseLibrary.Caching, Version=5.0.414.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
           name="NullBackingStore" />
    </backingStores>
