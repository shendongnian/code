    public IEnumerable<IEnumerable<int>> GetSubLists(int[] collection)
    {
       for(int i = 0; i< collection.Length; i++)
           yield return collection.Skip(i).Take(4);
    }
    GetSubLists(original).Select(l => l.Max());
