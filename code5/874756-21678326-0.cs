     public partial class MainWindow : Window
        {
           
            public MainWindow()
            {
                InitializeComponent();
                this.DataContext = new MyViewModel();  
            }
        }
        public class MyViewModel
    
        {
              public MyViewModel()
              {
                  for (int i = 0; i < 1; i++)
                  {
                      _obsCollection.Add(new Tuple<string, string, string>("Test" + i, "Test2" + i, "Test3" + i));   
                  }
              }
            ObservableCollection<Tuple<string, string, string>> _obsCollection = new ObservableCollection<Tuple<string, string, string>>();
    
            public ObservableCollection<Tuple<string, string, string>> MyObsCollection
            {
                get { return _obsCollection; }
    
            }
        }
