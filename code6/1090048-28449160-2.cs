      public class DataSourceRequest
      {
        public int Page { get; set; }
    
        public int PageSize { get; set; }
    
        public IList<SortDescriptor> Sorts { get; set; }
    
        public IList<IFilterDescriptor> Filters { get; set; }
    
        public IList<GroupDescriptor> Groups { get; set; }
    
        public IList<AggregateDescriptor> Aggregates { get; set; }
    
        public DataSourceRequest()
        {
          this.Page = 1;
          this.Aggregates = (IList<AggregateDescriptor>) new List<AggregateDescriptor>();
        }
      }
