        private IList<NetworkStatus> NetworkStatuses
        {
            get
            {
                IList<NetworkStatus> networkStatuses;
                Cache cache = HttpContext.Current.Cache;
                if (cache[NETWORK_STATUSES_CACHE_KEY] == null)
                {
                    networkStatuses = m_networkOwnerService.GetNetworkStatuses();
                    cache.Add(NETWORK_STATUSES_CACHE_KEY, networkStatuses, null, Cache.NoAbsoluteExpiration, new TimeSpan(0, 5, 0), CacheItemPriority.Default, null);
                }
                else
                {
                    networkStatuses = (IList<NetworkStatus>) cache[NETWORK_STATUSES_CACHE_KEY];
                }
                return networkStatuses;
            }
        }
