    class PagedResult<T> : List<T>
	{
		public int PageSize { get; set; }
		public int PageIndex { get; set; }
		public int TotalItems { get; set; }
		public int TotalPages { get; set; }
	}
    public static class Extensions
    {
        public static string ToPagedJson<T>(this PagedResult<T> pagedResult)
        {
             return JsonConvert.SerializeObject(new
             {
                 PageSize = pagedResult.PageSize,
			     PageIndex = pagedResult.PageIndex,
			     TotalItems = pagedResult.TotalItems,
			     TotalPages = pagedResult.TotalPages
                 Items = pagedResult
             });
        }
    }
