    public class CollectionWrapper<T>  
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        private IList<T> _collection;
        public IList<T> Collection
        {
            get { return _collection; }
            set { _collection = value; }
        }     
        public string DisplayMemeberPath
        {
           get;set;
        } 
       
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }
   
        public List<string> GetNewList()
        {
            return new List<string>
            {
               "1","2","3","4","1","2","3","4","1","2","3","4","1","2","3","4"
            };
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Items.Add(new CollectionWrapper<string> { Collection = GetNewList(), Title = (Items.Count + 1 ).ToString() }); 
        }
        private ObservableCollection<CollectionWrapper<string>> _items;
        public ObservableCollection<CollectionWrapper<string>> Items
        {
            get
            {
                if (_items == null)
                    _items = new ObservableCollection<CollectionWrapper<string>>();
                return _items;
            }
        }
    }
    
