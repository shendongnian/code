        private void AddHourlyTask(string task)
        {
            DateTime expiration = DateTime.Now.AddHours(1);
            expiration = new DateTime(expiration.Year, expiration.Month, expiration.Day, expiration.Hour, expiration.Minute, expiration.Second, expiration.Kind);
            OnCacheRemove = new CacheItemRemovedCallback(CacheItemRemoved);
            HttpRuntime.Cache.Insert(
                task,
                task,
                null,
                expiration,
                Cache.NoSlidingExpiration,
                CacheItemPriority.NotRemovable,
                OnCacheRemove);
        }
