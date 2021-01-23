    //Null-checks omitted for brevity:
    public static class DictionaryAsSet
    {
      //Note that some, but not all, of these methods allow one to use two dictionaries
      //with different types of value, as long as they've the same type of key.
      //They also assume that the same `IEqualityComparer<TKey>` is used, and will be
      //weird in results otherwise.
      public static void ExceptWithByKey<TKey, TValue1, TValue2>(this IDictionary<TKey, TValue1> dictionary, IDictionary<TKey, TValue2> other)
      {
        if(dictionary.Count != 0)
        {
          if(dictionary == (object)other)
            dictionary.Clear();
          else
            foreach(TKey key in other.Keys)
              dictionary.Remove(key);
        }
      }
      public static void IntersectWithByKey<TKey, TValue1, TValue2>(this IDictionary<TKey, TValue1> dictionary, IDictionary<TKey, TValue2> other)
      {
        if(dictionary.Count != 0 && dictionary != (object)other )
        {
          List<TKey> toRemove = new List<TKey>();
          foreach(TKey key in other.Keys)
            if(!dictionary.ContainsKey(key))
              toRemove.Add(key);
          if(toRemove.Count == dictionary.Count)
            dictionary.Clear();
          else
            foreach(TKey key in toRemove)
              dictionary.Remove(key);
        }
      }
      public static bool IsSubsetOfByKey<TKey, TValue1, TValue2>(this IDictionary<TKey, TValue1> dictionary, IDictionary<TKey, TValue2> other)
      {
        if(dictionary.Count == 0 || dictionary == (object)other)
          return true;
        if(dictionary.Count > other.Count)
          return false;
        foreach(TKey key in dictionary.Keys)
          if(!other.ContainsKey(key))
            return false;
        return true;
      }
      public static bool IsProperSubsetOfByKey<TKey, TValue1, TValue2>(this IDictionary<TKey, TValue1> dictionary, IDictionary<TKey, TValue2> other)
      {
        return dictionary.Count < other.Count && dictionary.IsSubsetOfByKey(other);
      }
      public static bool IsSupersetOfByKey<TKey, TValue1, TValue2>(this IDictionary<TKey, TValue1> dictionary, IDictionary<TKey, TValue2> other)
      {
        return other.IsSubsetOfByKey(dictionary);
      }
      public static bool IsProperSupersetOfByKey<TKey, TValue1, TValue2>(this IDictionary<TKey, TValue1> dictionary, IDictionary<TKey, TValue2> other)
      {
        return other.IsProperSubsetOfByKey(dictionary);
      }
      public static bool OverlapsByKey<TKey, TValue1, TValue2>(this IDictionary<TKey, TValue1> dictionary, IDictionary<TKey, TValue2> other)
      {
        if(dictionary.Count == 0 || other.Count == 0)
          return true;
        if(dictionary == (object)other)
          return true;
        foreach(TKey key in dictionary.Keys)
          if(other.ContainsKey(key))
            return true;
        return false;
      }
      public static bool SetEqualsByKey<TKey, TValue1, TValue2>(this IDictionary<TKey, TValue1> dictionary, IDictionary<TKey, TValue2> other)
      {
        if(dictionary == (object)other)
          return true;
        if(dictionary.Count != other.Count)
          return false;
        foreach(TKey key in dictionary.Keys)
          if(!other.ContainsKey(key))
            return false;
        return true;
      }
      public static void SymmetricExceptWithByKey<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, IDictionary<TKey, TValue> other)
      {
        if(dictionary.Count == 0)
          dictionary.UnionWithByKey(other);
        else if(dictionary == other)
          dictionary.Clear();
        else
        {
          List<TKey> toRemove = new List<TKey>();
          List<KeyValuePair<TKey, TValue>> toAdd = new List<KeyValuePair<TKey, TValue>>();
          foreach(var kvp in other)
            if(dictionary.ContainsKey(kvp.Key))
              toRemove.Add(kvp.Key);
            else
              toAdd.Add(kvp);
          foreach(TKey key in toRemove)
            dictionary.Remove(key);
          foreach(var kvp in toAdd)
            dictionary.Add(kvp.Key, kvp.Value);
        }
      }
      public static void UnionWithByKey<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, IDictionary<TKey, TValue> other)
      {
        foreach(var kvp in other)
          if(!dictionary.ContainsKey(kvp.Key))
            dictionary.Add(kvp.Key, kvp.Value);
      }
    }
