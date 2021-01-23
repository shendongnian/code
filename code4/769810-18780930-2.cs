    public class DataGrid1SourceItem
    {
        private List<DetailItems> _allDetailItems = new List<DetailItems>();
        public IEnumerable<DetailItem> DetailItems 
        {
           get { return _allDetailItems.Where(item => item.Name = ProductName); }
        } 
        public DataGrid1SourceItem()
        {
           // load your products into _allDetailItems
        }
        private string _productName;
        public string ProductName
        {
            get { return _productName; }
            set
            {
                _productName= value;
                OnPropertyChanged("ProductName");
                OnPropertyChanged("DetailItems");
            }
        }
    }
