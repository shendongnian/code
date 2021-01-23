    public class PageViewModel<TEntity>
    {
       public int TotalCount { get; private set; }
       public int FilteredCount { get; private set; }
       public IEnumerable<TEntity> Records { get; private set; }
       public int RecordsPerPage { get; private set; }
       // Help with some jQuery libs to help counting the number of pages to display...
       public int AvailablePages { get; private set; }
       /* Constructor */
    }
