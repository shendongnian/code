    using(var hmac = new HMACSHA256())
    {
        hmac.Key = salt;
        key = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
    }
