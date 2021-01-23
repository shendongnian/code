    using System;
    using System.Collections.Generic;
    
    namespace YourNamespace
    {
       public static class SortedDictionaryExtensions
       {
          public static SortedDictionary<TKey, TValue> ToSortedDictionary<TSource, TKey, TValue>(
             this IEnumerable<TSource> source,
             Func<TSource, TKey> keySelector,
             Func<TSource, TValue> valueSelector)
          {
             var result = new SortedDictionary<TKey, TValue>();
             
             foreach (TSource item in source)
             {
                TKey key = keySelector(item);
                TValue value = valueSelector(item);
                result.Add(key, value);
             }
             
             return result;
          }
       }
    }
