    class PagedResult<T> : List<T>
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
    }
