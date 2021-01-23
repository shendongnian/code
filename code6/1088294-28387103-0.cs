        public class IndexValuePair
        {
            public string Index {get;set;}
            public int Value {get;set;}
        }
    
        public static IEnumerable<IEnumerable<T>> GetPowerSet<T>(List<T> list)
        {
             return from m in Enumerable.Range(0, 1 << list.Count)
                   select
                         from i in Enumerable.Range(0, list.Count)
                         where (m & (1 << i)) != 0
                         select list[i];
        }
