    public class SearchDTO<T>
    {
        public object Id { get; set; }
        public IList<T> SearchResults { get; set; }
        public int PageSize { get; set; }
        public int StartRowNo
        {
            get
            {
                return (CurrentPage - 1) * PageSize;
            }           
        }
        public int CurrentPage { get; set; }
    
    }
