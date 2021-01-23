    public List<MonitoringEvent> GetAll()
    {
        using (var redis = this.redisManager.GetClient())
        {
            var _eventsCache = redis.As<CachedMonitoringEvent>();
            IList<CachedMonitoringEvent> allEvents = _eventsCache.GetAll();
    
            return allEvents
                .Where(e => e.MonitoringEvent != null)
                .Select(e => e.MonitoringEvent)
                .ToList();
        }
    }
