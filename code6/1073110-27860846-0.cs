    public void AddOrUpdate(MonitoringEvent monitoringEvent)
    {
        if (monitoringEvent == null)
            return;
    
        try
        {
            using (var redis = this.redisManager.GetClient())
            {
                var _eventsCache = redis.As<CachedMonitoringEvent>();
                var cacheExpiresAt = DateTime.Now.Add(CacheExpirationDuration);
    
                CachedMonitoringEvent cachedEvent;
    
                string eventKey = CachedMonitoringEvent.CreateUrnId(monitoringEvent);
                if (_eventsCache.ContainsKey(eventKey))
                {
                    cachedEvent = _eventsCache[eventKey];
                    cachedEvent.SetExpiresAt(cacheExpiresAt);
                    cachedEvent.MonitoringEvent = monitoringEvent;
                }
                else
                    cachedEvent = new CachedMonitoringEvent(monitoringEvent, cacheExpiresAt);
    
                _eventsCache.SetEntry(eventKey, cachedEvent, CacheExpirationDuration);
            }
        }
        catch (Exception ex)
        {
            Log.Error("Error while caching MonitoringEvent", ex);
        }
    }
