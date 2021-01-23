    using StackExchange.Redis;
    using StackExchange.Redis.Extensions.Core.Abstractions;
    using StackExchange.Redis.Extensions.Core.Configuration;
    using System;
    using System.Collections.Concurrent;
    using System.Linq;
    namespace Pool.Redis
    {
    /// <summary>
    /// Provides redis pool
    /// </summary>
    public class RedisConnectionPool : IRedisCacheConnectionPoolManager
    {
        private static ConcurrentBag<Lazy<ConnectionMultiplexer>> connections;
        private readonly RedisConfiguration redisConfiguration;
        public RedisConnectionPool(RedisConfiguration redisConfiguration)
        {
            this.redisConfiguration = redisConfiguration;
            Initialize();
        }
        public IConnectionMultiplexer GetConnection()
        {
            Lazy<ConnectionMultiplexer> response;
            var loadedLazys = connections.Where(lazy => lazy.IsValueCreated);
            if (loadedLazys.Count() == connections.Count)
            {
                response = connections.OrderBy(x => x.Value.GetCounters().TotalOutstanding).First();
            }
            else
            {
                response = connections.First(lazy => !lazy.IsValueCreated);
            }
            return response.Value;
        }
        private void Initialize()
        {
            connections = new ConcurrentBag<Lazy<ConnectionMultiplexer>>();
            for (int i = 0; i < redisConfiguration.PoolSize; i++)
            {
                connections.Add(new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(redisConfiguration.ConfigurationOptions)));
            }
        }
        public void Dispose()
        {
            var activeConnections = connections.Where(lazy => lazy.IsValueCreated).ToList();
            activeConnections.ForEach(connection => connection.Value.Dispose());
            Initialize();
        }
    }
