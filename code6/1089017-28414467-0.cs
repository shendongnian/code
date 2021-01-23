    /// <summary>
    /// Create a key from a String
    /// </summary>
    public static implicit operator RedisKey(string key)
    {
        if (key == null) return default(RedisKey);
        return new RedisKey(null, key);
    }
