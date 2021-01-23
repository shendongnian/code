    public interface IPagingDetails
    {
        int CurrentPage { get; set; }
        int TotalPages { get; set; }
        int TotalCount { get; set; }
    }
    public class PagingDetails : IPagingDetails
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
    }
