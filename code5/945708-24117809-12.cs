    using (var redisClient = new RedisClient())
    {
        IRedisTypedClient<Pizza> redis = redisClient.As<Pizza>();
        var pizzaKey = string.Format("pizzas:live:{0}", pizza.Id);
        var pizza = redis.GetValue(pizzaKey); // Get
        pizza.State = "Delivery"; // Update
        redis.SetEntry(pizzaKey, pizza); // Save
    }
