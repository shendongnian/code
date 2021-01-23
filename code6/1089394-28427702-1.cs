    namespace WavTest
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                var vm = new ViewModel();
                this.DataContext = vm;
    
                vm.TestSource.Add(new TestItem { Description="Zero", Order=0 });
            }
        }
    
        public class ViewModel 
        {
            public ObservableCollection<TestItem> TestSource { get; set; }
    
            public ViewModel()
            {
                TestSource = new ObservableCollection<TestItem>();
                TestSource.Add(new TestItem { Description = "Second", Order = 2 });
                TestSource.Add(new TestItem { Description = "Third", Order = 3 });
                TestSource.Add(new TestItem { Description = "First", Order = 1 });
            }
        }
    
        public class TestItem
        {
            public int Order { get; set; }
            public string Description { get; set; }
        }
    }
