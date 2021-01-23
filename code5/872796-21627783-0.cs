    public Task<String> GetStuffAsync(String url)
    {
        return _cache.AddOrUpdate(
            url, GetStuffInternalAsync, (u, task) =>
            {
                if (task.IsCanceled || task.IsFaulted)
                    return GetStuffInternalAsync(u);
                return task;
            });
    }
