    var result = list.Aggregate(
            new List<KeyValuePair<string, int>>(),
            (cache, s) =>
            {
                var last = cache.Reverse().FirstOrDefault(p => p.Key == s);
                if (last == null)
                {
                    cache.Add(new KeyValuePair<string, int>(s, 0));
                }
                else
                {
                    if (last.Value = 0)
                    {
                        last.Value = 1;
                    }
                    cache.Add(new KeyValuePair<string, int>(s, last.Value + 1));
                }
                return cache;
            },
            cache => cache.Select(p => p.Value == 0 ? 
                p.Key :
                p.Key + p.Value.ToString()));
