    public virtual void RemoveKey(string item, string id)
    {
       Task[] removeTasks = new Task[item.Length];
       for (int i = 1; i <= item.Length; i++)
       {
          Console.WriteLine(PrefixKey + item.Substring(0, i));
          removeTasks[i-1] = _redisClient.SortedSets.Remove(_database, 
                 PrefixKey + item.Substring(0, i), id);
       }
    
       _redisClient.WaitAll(removeTasks);
    }
