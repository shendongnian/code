    public virtual Task<Store> GetStoreByUsernameAsync(string username)
    {
        return _cacheManager.GetAsync(string.Format("Cache_Key_{0}", username), () =>
        {
            return _storeRepository.GetSingleAsync(x => x.UserName == username);
        });
    }
