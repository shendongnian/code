    public string Get(string key, Func<string> getItemCallback) 
            {
                var item = Cache.Get(key) as string;
                if (item == null)
                {
                    item = db.SomeConfigurationTable.SingleOrDefault(key);
                    Cache.Store(key, item);
                }
                return item;
            }
