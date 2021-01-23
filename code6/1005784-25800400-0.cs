    public class PagedResult<T>
        {
            public PagedResult(IEnumerable<T> data, long total)
            {
                Data = data;
                Total = total;
            }
            public PagedResult()
            {
            }
            public IEnumerable<T> Data { get; set; }
            public long Total { get; set; }
    
        }
