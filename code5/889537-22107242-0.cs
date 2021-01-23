    public void RemoveMultiple<T>(List<T> list, params int[] indexes)
    {
       var sortedIndexes = indexes.OrderByDescending(i => i);
       foreach(var indexToRemove in sortedIndexes)
       {
          list.RemoveAt(indexToRemove);
       }
    }
