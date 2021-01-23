        public static void SetData(string key, RedisObject data,bool bPictureServer)
        {
            string serverStr = ConfigurationManager.AppSettings["redisserverPicture"];
            if (!bPictureServer) serverStr = ConfigurationManager.AppSettings["redisStateServer"];
            using (var redis = ConnectionMultiplexer.Connect(serverStr))
            {
                IDatabase db = redis.GetDatabase();
                db.StringSet(data.key, HtmlHelperExtensions.JSONSerializeObject(data));
                redis.Close();
            }
        }
        public static RedisObject GetData(string key,bool bPictureServer)
        {
            string serverStr = ConfigurationManager.AppSettings["redisserverPicture"];
            if (!bPictureServer) serverStr = ConfigurationManager.AppSettings["redisStateServer"];
            using (var redis = ConnectionMultiplexer.Connect(serverStr))
            {
                try
                {
                    IDatabase db = redis.GetDatabase();
                    var res = db.StringGet(key);
                    redis.Close();
                    if (res.IsNull)
                        return null;
                    else
                        return HtmlHelperExtensions.DeserializeObject<RedisObject>(res);
                }
                catch
                {
                    return null;
                }
                
            }
        }
        public static void SetData<T>(string key, T data, bool bPictureServer)
        {
            string serverStr = ConfigurationManager.AppSettings["redisserverPicture"];
            if (!bPictureServer) serverStr = ConfigurationManager.AppSettings["redisStateServer"];
            using (var redis = ConnectionMultiplexer.Connect(serverStr))
            {
                IDatabase db = redis.GetDatabase();
                db.StringSet(key, HtmlHelperExtensions.JSONSerializeObject(data));
                redis.Close();
            }
        }
        public static T GetData<T>(string key, bool bPictureServer)
        {
            string serverStr = ConfigurationManager.AppSettings["redisserverPicture"];
            if (!bPictureServer) serverStr = ConfigurationManager.AppSettings["redisStateServer"];
            using (var redis = ConnectionMultiplexer.Connect(serverStr))
            {
                try
                {
                    IDatabase db = redis.GetDatabase();
                    var res = db.StringGet(key);
                    redis.Close();
                    if (res.IsNull)
                        return default(T);
                    else
                        return HtmlHelperExtensions.DeserializeObject<T>(res);
                }
                catch
                {
                    return default(T);
                }
            }
        }
        public static void DeleteData(string key,bool bPictureServer)
        {
            string serverStr = ConfigurationManager.AppSettings["redisserverPicture"];
            if (!bPictureServer) serverStr = ConfigurationManager.AppSettings["redisStateServer"];
            using (var redis = ConnectionMultiplexer.Connect(serverStr))
            {
                IDatabase db = redis.GetDatabase();
                db.KeyDelete(key);
                redis.Close();
            }
        }
    }
