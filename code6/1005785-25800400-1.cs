    public class PageInfo
        {
            
            public int Page { get; set; }           
            public int PageSize { get; set; }
            public int Skip
            {
                get
                {
                    return PageSize*(Page - 1);
                }
            }
    
            public PageInfo(int page, int pageSize)
            {
                Page = page;
                PageSize = pageSize;
            }
    
        }
