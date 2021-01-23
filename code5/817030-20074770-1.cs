    public class ProductsListViewModel
    {
        public IEnumerable<ProductAndFilterVM> FilterProducts { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
        public IEnumerable<ProductFilter> ProductFilters { get; set; }
    }
