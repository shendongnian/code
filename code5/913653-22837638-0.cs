    var cache = MemoryCache.Default;
    
                var firstObject = cache["firstObject"] as string;
                if (firstObject == null)
                {
                    var cmd = new SqlCommand("SELECT * FROM Table1");
                    firstObject = GetFirstObject(cmd);
                    var policy = new CacheItemPolicy();
                    policy.ChangeMonitors.Add(new SqlChangeMonitor(new SqlDependency(cmd, null, 600)));
                    cache.Add("firstObject", firstObject, policy);
                }
    
                var secondObject = cache["secondObject"] as string;
                if (secondObject == null)
                {
                    var cmd = new SqlCommand("SELECT * FORM Table2");
                    secondObject = GetSecondObject(cmd);
                    var policy = new CacheItemPolicy();
                    policy.ChangeMonitors.Add(new SqlChangeMonitor(new SqlDependency(cmd, null, 600)));
                    cache.Add("secondObject", secondObject, policy);
                }
