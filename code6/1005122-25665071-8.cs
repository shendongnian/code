    int page = 3;
    int pageSize = 10;
    int startAt = pageSize * page;
    int endAt = startAt + pageSize;
    using (var redis = new RedisClient())
    {
        var pagedCustomerKeys = redis.ScanAllKeys("Customer:*", endAt).ToList().Skip(startAt).Take(pageSize);
        var pagedCustomers = redis.GetValues<CustomerR>(pagedCustomerKeys);
    }
