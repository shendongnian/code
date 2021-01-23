    public class Todo
    {
        public long Id { get; set; }
        public string Content { get; set; }
        public int Order { get; set; }
        public bool Done { get; set; }
    }
    IRedisClient redis = redisManager.GetClient();
    var redisTodos = redis.As<Todo>(); 
