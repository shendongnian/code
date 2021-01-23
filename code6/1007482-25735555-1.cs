    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    
    class Program
    {
        static int index = 0;
    
        private static void Main(string[] args)
        {
            Dictionary<int, string> pNames = new Dictionary<int, string>();
            pNames.Add(1, "value1");
            pNames.Add(2, "value2");
            var bUsers = new List<string>() { "value1" };
    
            var newKey = bUsers.ToDictionary(idx =>
            {
                return index++;
            }, x => x);
    
            var result = pNames.Except(newKey, new CustomIEqualityComparer<int, string>());
        }
    
        public class CustomIEqualityComparer<TSource, TValue> : IEqualityComparer<KeyValuePair<TSource, TValue>>
        {
            public bool Equals(KeyValuePair<TSource, TValue> x, KeyValuePair<TSource, TValue> y)
            {
                return x.Value.Equals(y.Value);
            }
    
            public int GetHashCode(KeyValuePair<TSource, TValue> obj)
            {
                unchecked
                {
                    int hash = 17;
                    hash = hash * 23 + obj.Value.GetHashCode();
                    return hash;
                }
            }
        }
    }
