        public static void Refresh()
        {
            var factory = _factory; if (factory != null)
            {
                factory.Dispose();
                _factory = null;
            }
            _cache = null;
            DataCacheFactory.Reinitialize();
            DistributedCacheSessionStateStoreProvider.Reinitialize();
        }
