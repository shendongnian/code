    class Program
    {
        static void Main(string[] args)
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");
            var db = redis.GetDatabase(0);
            var timeToLive = db.KeyTimeToLive("RedisKeyNameHere");
        }
    }
