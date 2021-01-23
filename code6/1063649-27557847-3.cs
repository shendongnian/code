    public interface IPagingDetails
    {
        int CurrentPage { get; set; }
        int TotalPages { get; set; }
        int TotalCount { get; set; }
        bool HasPreviousPage { get; }
        int PreviousPage { get; }
        bool HasNextPage { get; }
        int NextPage { get; }
    }
    public class PagingDetails : IPagingDetails
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
        public bool HasPreviousPage
        {
            get { return CurrentPage > 1; }
        }
        public int PreviousPage
        {
            get { return CurrentPage - 1; }
        }
        public bool HasNextPage
        {
            get { return CurrentPage < TotalPages; }
        }
        public int NextPage
        {
            get { return CurrentPage + 1;}
        }
    }
