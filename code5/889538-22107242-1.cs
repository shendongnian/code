    public void RemoveMultiple<T>(List<T> list, params int[] indexes)
    {
       // if this next line gives you a compiler error, you need to include
       // linq by putting a "using System.Linq;" at the very top of the file.
       var sortedIndexes = indexes.OrderByDescending(i => i);
       foreach(var indexToRemove in sortedIndexes)
       {
          list.RemoveAt(indexToRemove);
       }
    }
