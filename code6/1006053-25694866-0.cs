    public class Product : INotifyPropertyChanged
    {
        private static readonly IDictionary<string, string[]> catalog = new Dictionary<string, string[]>
        {
            { "Fruit", new[]{ "Apple", "Banana", "Cherry" } },
            { "Vegatable", new[]{ "Amaranth", "Broccolini", "Celery" } }
        };
        public static IDictionary<string, string[]> Catalog { get { return catalog; } }
        private string productLineCategoryCode;
        public string ProductLineCategoryCode
        {
            get { return productLineCategoryCode; }
            set
            {
                if (value != productLineCategoryCode)
                {
                    productLineCategoryCode = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("ProductLineCategoryCode"));
                    PropertyChanged(this, new PropertyChangedEventArgs("ProductLineCodes"));
                }
            }
        }
        public IEnumerable<string> ProductLineCodes
        {
            get
            {
                return Catalog[ProductLineCategoryCode];
            }
        }
        private string productLineCode;
        public string ProductLineCode
        {
            get { return productLineCode; }
            set
            {
                if (value != productLineCode)
                {
                    productLineCode = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("ProductLineCode"));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
