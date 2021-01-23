    config.MessageHandlers.Add(new ThrottlingHandler()
    {
        // Generic rate limit applied to ALL APIs
        Policy = new ThrottlePolicy(perSecond: 1, perMinute: 20, perHour: 200)
        {
            IpThrottling = true,
            ClientThrottling = true,
            EndpointThrottling = true,
            EndpointRules = new Dictionary<string, RateLimits>
            { 
                 //Fine tune throttling per specific API here
                { "api/search", new RateLimits { PerSecond = 10, PerMinute = 100, PerHour = 1000 } }
            }
        },
        Repository = new CacheRepository()
    });
