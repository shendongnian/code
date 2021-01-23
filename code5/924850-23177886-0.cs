    <Window xmlns:vm="clr-namespace:YourProject.YourViewModelNamespace">
        <Window.DataContext>
            <vm:YourViewViewModel />
        </Window.DataContext>
        <ComboBox ItemsSource="{Binding GameProfileListItems}"/>
    </Window>
    public class YourViewViewModel : ViewModelBase (this is something that implements INotifyPropertyChanged)
    {
        ObservableCollection<string> _gameProfileListItems;
        ObservableCollection<string> GameProfileListItems
        {
            get { return _gameProfileListItems; }
            set { _gameProfileListItems = value; OnPropertyChanged("GameProfileListItems"); }
        }
        
        public void SetGameProfileListItems()
        {
            //    go and get your data here, transfer it to an observable collection
            //    and then assign it to this.GameProfileListItems (i would recommend writing a .ToObservableCollection() extension method for IEnumerable)
            this.GameProfileListItems = SomeManagerOrUtil.GetYourData().ToObservableCollection();
        }
    }
    public class YourView : Window
    {
        public void YourView()
        {
            InitializeComponent();
            InitializeViewModel();
        }
        YourViewViewModel ViewModel
        {
            { get return this.DataContext as YourViewViewModel; }
        }
        void InitializeViewModel()
        {
            this.ViewModel.SetGameProfileListItems();
        }
    }
