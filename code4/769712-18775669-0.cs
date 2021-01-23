    <ListBox Margin="17.493,33.32,22.491,26.656" Name="lstData"   
             PreviewMouseLeftButtonDown="ListBox_MouseDown"
             IsTextSearchEnabled="False"
             ItemsSource="{Binding MyItems}"
             SelectedItem="{Binding MySelectedItem}"/>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {  
            InitializeComponent();
            DataContext = this;
        }
        private ObservableCollection<MyItemType> _myItems = new ObservableCollection<MyItemType>();
        public ObservableCollection<MyItemType> MyItems
        {
            get { return _myItems; }
            set { _myItems = value; }
        }
        private MyItemType _mySelectedItem;
        public MyItemType MySelectedItem
        {
            get { return _mySelectedItem; }
            set { _mySelectedItem = value; NotifyPropertyChanged("MySelectedItem"); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string p)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(p));
            }
        }
        
    }
