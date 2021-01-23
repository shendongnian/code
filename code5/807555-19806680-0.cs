    public class ViewModel: INotifyPropertyChanged
    {
        private DBContext context = new DBContext("Data source=isostore:/names2.sdf");
        private ObservableCollection<NameTable> nameCollection;
    
        public ObservableCollection<NameTable> NameCollection
        {
            get
            {
                return nameCollection;
            }
            set
            {
                if (nameCollection != value)
                {
                    nameCollection = value;
                    OnPropertyChanged("NameCollection");
                }
            }
        }
    
        public void AddNewNameSecondWay(string s)
        {
           // your code
           OnPropertyChanged("NameCollection");
        }
    
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
           PropertyChangedEventHandler handler = PropertyChanged;
           if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
