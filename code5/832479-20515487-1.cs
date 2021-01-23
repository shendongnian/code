    IList<IList<T>> AddColumn(this IList<IList<T>> source, IList<T> column)
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
