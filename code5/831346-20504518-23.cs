    public static class DictionaryAsSetEnumerable
    {
      //we could also return IEnumerable<KeyValuePair<TKey, TValue1>> if we wanted
      public static IEnumerable<TValue1> Except<TKey, TValue1, TValue2>(this IDictionary<TKey, TValue1> dictionary, IDictionary<TKey, TValue2> other)
      {
        if(dictionary.Count != 0 && dictionary != (object)other)
        {
           foreach(var kvp in dictionary)
             if(!other.ContainsKey(kvp.Key))
               yield return kvp.Value;
        }
      }
      //And so on. The approach for each here should be clear from those above 
    }
