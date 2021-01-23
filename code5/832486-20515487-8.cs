    void AddColumn(this List<List<T>> source, IList<T> column)
    {
       if (column is null)
       {
           throw new ArgumentNullException("column");
       }
       if (column.Count != source.Count)
       {
           throw new ArgumentException("column");
       }
       for(var i = 0; i < source.Count; i++)
       {
           source[i].Add(column[i]);
       }
    }
