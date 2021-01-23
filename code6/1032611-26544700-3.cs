    class ResultSet<T> : IResultSet<T>
    {
         private IQueryable<T> data;
         private List<IFilter> filters = new List<IFilter>();
         public int OriginalCount {get; private set;}
         public int FilteredCount 
         {
             get { return Result.Count(); }
         }
         public IEnumerable<T> Result 
         {
             get 
             {
                 IQueryable data = this.data;
                 foreach(IFilter filter in filters)
                 {
                     data = filter.Filter(data);
                 }
                 return data;
             }
         }
         
         //constructor
         public ResultSet<T>(IQueryable<T> data)
         {
              this.data = data;
              this.OriginalCount = data.Count();              
         }
         public void AddFilter(IFilter<T> filter)
         {
             this.filters.Add(filter);
         }
    }
