    public void UpdatePizza(Pizza pizza)
    {
        using (var redisClient = new RedisClient(Host, Port))
        {
            IRedisTypedClient<Pizza> redis = redisClient.As<Pizza>();
            IRedisList<Pizza> pizzas = redis.Lists["pizzas:live"];
            var toUpdate = pizzas.First(x => x.Id == pizza.Id);
            toUpdate.State = pizza.State;
            // Update by removing & inserting (don't do it!)
            var index = pizzas.IndexOf(toUpdate);
            pizzas.Remove(index);
            pizzas.Insert(index, toUpdate);
        }                   
    }
