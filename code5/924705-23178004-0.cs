    <Window xmlns:vm="clr-namespace:YourProject.YourViewModelNamespace"
            xmlns:vc="clr-namespace:YourProject.YourValueConverterNamespace>
        <Window.Resources>
            <vc:YourValueConverter x:key="YourValueConverter" />
        </Window.Resources>
        <Window.DataContext>
            <vm:YourViewViewModel />
        </Window.DataContext>
        <TextBox Text="{Binding MyItems, Converter={StaticResource YourValueConverter}}"/>
    </Window>
    public class YourViewViewModel : ViewModelBase
    {
        ObservableCollection<string> _myItems;
        ObservableCollection<string> MyItems
        {
            get { return _gameProfileListItems; }
            set { _gameProfileListItems = value; OnPropertyChanged("MyItems"); }
        }
        
        public void SetMyItems()
        {
            //    go and get your data here, transfer it to an observable collection
            //    and then assign it to this.GameProfileListItems (i would recommend writing a .ToObservableCollection() extension method for IEnumerable)
            this.MyItems = SomeManagerOrUtil.GetYourData().ToObservableCollection();
        }
    }
    public class YourView : Window
    {
        YourViewViewModel ViewModel
        {
            { get return this.DataContext as YourViewViewModel; }
        }
        public void YourView()
        {
            InitializeComponent();
            InitializeViewModel();
        }
        void InitializeViewModel()
        {
            this.ViewModel.SetMyItems();
        }
    }
