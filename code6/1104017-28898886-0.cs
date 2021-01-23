        public class data
        {
            public SomeData GetData(int id)
            {
                if (cache.Contains(id))
                {
                    return cache[id];
                }
                else
                {
                    SomeData data = GetDataFromDB(id);
                    cache[id] = data;
                    return data;
                }
            }
        }
