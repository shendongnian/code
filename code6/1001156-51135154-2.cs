        public static void SetData<T>(string key, T data)
        {
            using (var redis = ConnectionMultiplexer.Connect("localhost:6379"))
            {
                IDatabase db = redis.GetDatabase();
                JavaScriptSerializer json_serializer = new JavaScriptSerializer();
                json_serializer.MaxJsonLength = int.MaxValue;
            
                db.StringSet(key, json_serializer.Serialize(data));
                redis.Close();
            }
        }
        public static T GetData<T>(string key)
        {
            using (var redis = ConnectionMultiplexer.Connect("localhost:6379"))
            {
                try
                {
                    IDatabase db = redis.GetDatabase();
                    var res = db.StringGet(key);
                    redis.Close();
                    if (res.IsNull)
                        return default(T);
                    else
                        return JsonConvert.DeserializeObject<T>(res);
                }
                catch
                {
                    return default(T);
                }
            }
        }
