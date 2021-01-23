    public class DataTableRequest
    {
        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }
        public string Search { get; private set; }
        private List<SortBy> SortingColumns { get; set; }
    
        public int SEcho { get; private set; }
    
        public DataTableRequest(int pageIndex, int pageSize, string search, List<SortBy> sortingColumns, int sEcho)
        {   
            PageIndex = pageIndex;
            PageSize = pageSize;
            Search = search;
            SortingColumns = sortingColumns;
            SEcho = sEcho;
        }
    
        public string GetOrderByExpression()
        {
            // could be passed to EntityFramework with DynamicLinq like query.OrderBy(dataTableRequest.GetOrderByExpression())
            var columnDirectionPairs = SortingColumns.Select(c => Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(c.Column.Replace("_", ".")) + " " + c.Direction);
            var orderByExpression = string.Join(", ", columnDirectionPairs);
            return orderByExpression;
        }
    
        public class SortBy
        {
            public SortBy(string column, string direction)
            {
                Guard.ArgumentNotNullOrEmpty(column, "column");
                Guard.ArgumentNotNullOrEmpty(direction, "direction");
    
                Column = column;
                Direction = direction;
            }
    
            public string Column { get; set; }
            public string Direction { get; set; }
        }
    }
