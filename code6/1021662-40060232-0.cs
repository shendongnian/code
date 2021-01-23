        public static void SetItem<T>(string key, T value)
        {
            IDatabase redDb = GetDB();
            redDb.StringSet(key, ToByteArray<T>(value));
        }
        public static T GetItem<T>(string key)
        {
            IDatabase redDb = GetDB();
            RedisValue redisResult = redDb.StringGet(key);
            T objResult = FromByteArray<T>(redisResult);
            return objResult;
        }
       public static byte[] ToByteArray<T>(T obj)
       {
            if (obj == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }
        public static T FromByteArray<T>(byte[] data)
        {
            if (data == null)
                return default(T);
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream(data))
            {
                object obj = bf.Deserialize(ms);
                return (T)obj;
            }
        }
