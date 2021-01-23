        using ServiceStack.Redis;
        private static IRedisClientsManager GetRedisSentinel()
        {
            IRedisClientsManager redisManager = null;
            try
            {
                List<string> listSentinels = new List<string>();
                listSentinels.Add(ConfigurationManager.AppSettings["RedisDB1"]);
                listSentinels.Add(ConfigurationManager.AppSettings["RedisDB2"]);
                listSentinels.Add(ConfigurationManager.AppSettings["RedisDB3"]);
                listSentinels.Add(ConfigurationManager.AppSettings["RedisDB4"]);
                RedisSentinel redisSentinel = new RedisSentinel(listSentinels, ConfigurationManager.AppSettings["RedisMaster"]);
                redisSentinel.SentinelWorkerConnectTimeoutMs = 500;
                redisManager = redisSentinel.Start();
            }
            catch (Exception ex)
            {
                _log.Trace(ex, "Error Redis Connection: " + ex.Message);
            }
            
            return redisManager;
        }
        public static object GetRedisCache<T>(string key)
        {
            object myObject = null;
            //naming convention [PLATFORM]:[PROJECT]:[FUNCTION]:[PARAMETERS…]
            string redisKey = string.Format("WEB:MyProject:{0}:{1}", typeof(T), key);
            //Open Redis
            IRedisClientsManager redisManager = GetRedisSentinel();
            if (redisManager != null)
            {
                try
                {
                    using (RedisClient redis = (RedisClient)redisManager.GetClient())
                    {
                        //Redis and Object connection
                        var redisGateways = redis.As<T>();
                        //Check if the object exists with the key
                        myObject = redisGateways.GetValue(redisKey);
                    }
                }
                catch (Exception ex)
                {
                    _log.Trace(ex, "Error Get In Redis: " + ex.Message);
                }
            }
            return myObject;
        }
        public static void SaveRedisCache<T>(object myObject, string key, DateTime? expireDateTime = null)
        {
            if (expireDateTime == null)
                expireDateTime = DateTime.Now.AddMinutes(20);
            //naming convention [PLATFORM]:[PROJECT]:[FUNCTION]:[PARAMETERS…]
            string redisKey = string.Format("WEB:MyProject:{0}:{1}", typeof(T), key);
            if (myObject != null)
            {
                //Open Redis
                IRedisClientsManager redisManager = GetRedisSentinel();
                if (redisManager != null)
                {
                    try
                    {
                        using (RedisClient redis = (RedisClient)redisManager.GetClient())
                        {
                            //Redis and Object connection
                            var redisGateways = redis.As<T>();
                            //Store in Redis and put 20 minutes as expire
                            bool isExists = redisGateways.SetEntryIfNotExists(redisKey, (T)myObject);
                            if (isExists)
                                redisGateways.ExpireEntryAt(redisKey, (DateTime)expireDateTime);
                            else
                                redisGateways.SetEntry(redisKey, (T)myObject); //Update
                        }
                    }
                    catch (Exception ex)
                    {
                        _log.Trace(ex, "Error Save In Redis: " + ex.Message);
                    }
                }
            }
        }
        public static void EraseRedisCache<T>(string key)
        {
            //naming convention [PLATFORM]:[PROJECT]:[FUNCTION]:[PARAMETERS…]
            string redisKey = string.Format("WEB:MyProject:{0}:{1}", typeof(T), key);
            //Open Redis
            IRedisClientsManager redisManager = GetRedisSentinel();
            if (redisManager != null)
            {
                try
                {
                    using (RedisClient redis = (RedisClient)redisManager.GetClient())
                    {
                        //Redis and Object connection
                        var redisGateways = redis.As<T>();
                        redisGateways.RemoveEntry(redisKey);
                    }
                }
                catch (Exception ex)
                {
                    _log.Trace(ex, "Error Remove In Redis: " + ex.Message);
                }
            }
        }
