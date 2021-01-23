    public class MainWindowViewModel : BindableBase
    {
        //This will bind to the DataGrid instead of the TestEntities
        public CollectionViewSource ViewSource { get; set; }
        //Notice no OnPropertyChange, just a property
        public ObservableCollection<TestEntity> TestEntities { get; set; }
    
        public MainWindowViewModel()
            : base()
        {
            this.TestEntities = new ObservableCollection<TestEntity> {
            new TestEntity { Name = "Test", Count=0},
            new TestEntity { Name = "Test1", Count=1},
            new TestEntity { Name = "Test2", Count=2},
            new TestEntity { Name = "Test3", Count=3}
        };
    
            this.UpCommand = new DelegateCommand(this.MoveUp);
    
            //Initialize the view source and set the source to your observable collection
            this.ViewSource = new CollectionViewSource();
            ViewSource.Source = this.TestEntities;
        }
    
        public ICommand UpCommand { get; private set; }
    
        private void MoveUp()
        {
            //Here is a dummy edit to show the modification of a element within the observable collection
            var i = this.TestEntities.FirstOrDefault();
            i.Count = 5;
            //Now anytime you want the datagrid to refresh you can call this.
            ViewSource.View.Refresh();
        }
    }
